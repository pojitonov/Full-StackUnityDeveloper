using UnityEngine;

namespace ShootEmUp
{
    public class EnemyFireHandler : IEnemyFireHandler
    {
        private readonly BulletManager bulletManager;

        public EnemyFireHandler(BulletManager bulletManager)
        {
            this.bulletManager = bulletManager;
        }

        public void OnFire(Vector2 position, Vector2 direction)
        {
            bulletManager.SpawnBullet(
                position,
                Color.red,
                (int)PhysicsLayer.ENEMY_BULLET,
                1,
                false,
                direction * 2
            );
        }
    }
}