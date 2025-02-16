using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MeleeInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private Transform _center;
        [SerializeField] private float _stoppingDistance = 1f;
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _attackInterval = 0.1f;

        protected override void Install(IWeaponEntity entity)
        {
            // entity.AddAttackAction(new MeleeAttackAction(entity, _center, _stoppingDistance, _damage));
            // entity.AddAttackEvent(new BaseEvent());
            // entity.AddBehaviour(new AttackBehaviour(_attackInterval));
        }
    }
}