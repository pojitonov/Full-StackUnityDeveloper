using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class MeleeAttackAction : IAction
    {
        private readonly IEntity _entity;
        private readonly IEntity _target;
        private readonly Transform _center;
        private readonly float _stoppingDistance;
        private readonly int _damage;
        private readonly LayerMask _layerMask = LayerMask.GetMask("Character");
        
        public MeleeAttackAction(IEntity entity, Transform center, float stoppingDistance, int damage)
        {
            _entity = entity;
            _target = entity.GetTarget();
            _center = center;
            _stoppingDistance = stoppingDistance;
            _damage = damage;
        }

        public void Invoke()
        {
            if (_target == null)
                return;

            if (_entity.TryGetAttackCondition(out var condition) && !condition.Invoke())
                return;

            float distance = _entity.GetDistance(_target);

            if (distance < _stoppingDistance)
            {
                MeleeAttackUseCase.Attack(_entity, _center.position, _stoppingDistance, _damage, _layerMask);
                _entity.GetAttackEvent().Invoke();
            }
        }
    }
}