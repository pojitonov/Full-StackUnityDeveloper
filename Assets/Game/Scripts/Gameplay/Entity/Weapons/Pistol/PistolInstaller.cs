using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PistolInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private SceneEntity _bulletPrefab;
        [SerializeField] private Transform _firePoint;

        protected override void Install(IWeaponEntity entity)
        {
            //Data:
            entity.AddBulletPrefab(_bulletPrefab);
            entity.AddFirePoint(_firePoint);
            entity.AddFireEvent(new BaseEvent());
            
            //Conditions:
            entity.AddFireCondition(new Const<bool>(true));
            
            //Actions:
            entity.AddFireAction(new PistolFireAction(entity));
        }
    }
}