using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PistolInstaller : SceneEntityInstaller<IWeaponEntity>
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
            entity.AddFirePoint(_firePoint);
            entity.AddAmmo(_ammo);
            entity.AddFireEvent(new BaseEvent());
            
            //Conditions:
            entity.AddFireCondition(new BaseFunction<bool>(() => _ammo.Exists()));
            
            //Actions:
            entity.AddFireAction(new PistolFireAction(entity, gameContext));
        }
    }
}