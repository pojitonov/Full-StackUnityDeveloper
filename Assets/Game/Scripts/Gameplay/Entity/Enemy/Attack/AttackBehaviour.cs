using Atomic.Entities;
using Modules.Gameplay;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Game.Gameplay
{
    public class AttackBehaviour : IEntityInit<WeaponEntity>, IEntityUpdate<WeaponEntity>
    {
        private readonly Cooldown _cooldown;
        private readonly float _stoppingDistance;

        public AttackBehaviour(float attackInterval, float stoppingDistance)
        {
            _cooldown = new Cooldown(attackInterval);
            _stoppingDistance = stoppingDistance;
        }

        public void Init(WeaponEntity entity)
        {
            _cooldown.Reset();
        }

        public void OnUpdate(WeaponEntity entity, in float deltaTime)
        {
            _cooldown.Tick(deltaTime);

            if (_cooldown.IsExpired())
            {
                Attack(entity);
                _cooldown.Reset();
            }
        }

        private void Attack(WeaponEntity entity)
        {
            var target = entity.GetRoot().GetTarget();
            if (target == null || !target.IsAlive()) return;

            var distance = entity.GetDistance(target);
            if (distance < _stoppingDistance)
                entity.GetAttackEvent().Invoke();
        }
    }
}