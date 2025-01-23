using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class WeaponsInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private SceneEntity _bulletPrefab;
        [SerializeField] private Transform _firePoint;

        protected override void Install(IWeaponEntity entity)
        {
            //Data:
            entity.AddBulletPrefab(_bulletPrefab);
            entity.AddFirePoint(_firePoint);
            
            //Actions:

            //Conditions:

            //Behaviours:
        }
    }
}