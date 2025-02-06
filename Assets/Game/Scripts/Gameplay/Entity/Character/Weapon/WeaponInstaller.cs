using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class WeaponInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private SceneEntity _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Ammo _ammo;
        
        protected override void Install(IWeaponEntity entity)
        {
            //Contexts:
            GameContext gameContext = GameContext.Instance;
            
            //Data:
            entity.AddBulletPrefab(_bulletPrefab);
            entity.AddTransform(_firePoint);
            entity.AddAmmo(_ammo);
            entity.AddAttackEvent(new BaseEvent());
            
            //Conditions:
            entity.AddAttackCondition(new BaseFunction<bool>(() => _ammo.Exists()));
            
            //Actions:
            entity.AddAttackAction(new WeaponFireAction(entity, gameContext));
        }
    }
}