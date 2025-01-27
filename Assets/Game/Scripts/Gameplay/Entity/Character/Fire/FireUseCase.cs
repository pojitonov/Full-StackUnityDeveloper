using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class FireUseCase
    {
        public static IEntity FireBullet(this IWeaponEntity entity)
        {
            SceneEntity bulletPrefab = entity.GetBulletPrefab();
            Transform firePoint = entity.GetFirePoint();
            return SceneEntity.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}