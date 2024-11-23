using UnityEngine;

namespace ShootEmUp
{
    public class ShipAttack
    {
        private readonly Transform firePoint;
        private readonly bool isPlayer;
        private readonly BulletManager bulletManager;

        public ShipAttack(Transform firePoint, bool isPlayer, BulletManager bulletManager)
        {
            this.firePoint = firePoint;
            this.isPlayer = isPlayer;
            this.bulletManager = bulletManager;
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