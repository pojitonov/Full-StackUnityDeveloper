using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MeleeInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private float _attackInterval = 1f;
        [SerializeField] private float _stoppingDistance = 1f;
        [SerializeField] private int _damage = 10;
        [SerializeField] private SceneEntity _rootEntity;
        [SerializeField] private Transform _rootTransform;
        [SerializeField] private LayerMask _layerMask;
        
        protected override void Install(IWeaponEntity entity)
        {
            entity.AddTransform(_rootTransform);
            entity.AddAttackEvent(new BaseEvent());
            entity.AddBehaviour(new AttackBehaviour(_rootEntity, _attackInterval, _stoppingDistance));
            entity.AddAttackAction(new MeleeAttackAction(entity, _stoppingDistance, _damage, _layerMask));
        }
    }
}