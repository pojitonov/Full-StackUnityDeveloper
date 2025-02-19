using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MeleeInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private Transform _rootTransform;
        [SerializeField] private int _damage = 10;
        [SerializeField] private LayerMask _layerMask;
        
        protected override void Install(IWeaponEntity entity)
        {
            entity.AddTransform(_rootTransform);
            entity.AddMeleeAction(new MeleeAttackAction(entity, _damage, _layerMask));
        }
    }
}