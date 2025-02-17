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
            GameContext gameContext = GameContext.Instance;
            
            //Entity:
            entity.AddBulletPrefab(_bulletPrefab);
            entity.AddTransform(_firePoint);
            entity.AddAmmo(_ammo);
            
            //Attack:
            entity.AddAttackCondition(new BaseFunction<bool>(() => _ammo.Exists()));
            entity.AddAttackAction(new PistolFireAction(entity, gameContext));
            entity.AddAttackEvent(new BaseEvent());
        }
    }
}