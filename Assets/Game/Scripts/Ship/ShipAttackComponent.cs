using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public class ShipAttackComponent
    {
        [SerializeField]
        private Transform firePoint;
        
        private readonly bool isPlayer;
        private readonly BulletManager bulletManager;

        public Transform FirePoint
        {
            get => firePoint;
            set => firePoint = value;
        }

        public ShipAttackComponent(Transform firePoint, bool isPlayer, BulletManager bulletManager)
        {
            this.isPlayer = isPlayer;
            this.bulletManager = bulletManager;
            this.firePoint = firePoint;
        }

        public void Fire(Vector2 direction, BulletConfig bulletConfig)
        {
            Vector2 firePosition = FirePoint.position;
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