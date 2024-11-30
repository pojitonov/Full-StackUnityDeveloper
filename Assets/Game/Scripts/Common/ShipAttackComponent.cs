using UnityEngine;

namespace ShootEmUp
{
    public class ShipAttackComponent
    {
        private readonly bool isPlayer;
        private readonly Transform firePoint;
        private readonly BulletManager bulletManager;

        public ShipAttackComponent(Transform firePoint, bool isPlayer, BulletManager bulletManager)
        {
            this.isPlayer = isPlayer;
            this.bulletManager = bulletManager;
            this.firePoint = firePoint;
        }

        public void Fire(Vector2 direction, BulletConfig bulletConfig)
        {
            Vector2 firePosition = firePoint.position;
            bulletManager.SpawnBullet(
                firePosition,
                damage: 1,
                isPlayer,
                velocity: direction * bulletConfig.speed,
                bulletConfig.color,
                bulletConfig.layer);
        }
    }
}