using UnityEngine;

namespace ShootEmUp
{
    public class PlayerShooting : IPlayerShooting
    {
        private readonly Player character;
        private readonly BulletManager bulletManager;

        public PlayerShooting(Player character, BulletManager bulletManager)
        {
            this.character = character;
            this.bulletManager = bulletManager;
        }

        public void Shoot()
        {
            bulletManager.SpawnBullet(
                this.character.firePoint.position,
                Color.blue,
                (int)PhysicsLayer.PLAYER_BULLET,
                1,
                true,
                this.character.firePoint.rotation * Vector3.up * 3
            );
        }
    }
}