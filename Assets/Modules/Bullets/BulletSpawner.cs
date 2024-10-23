using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSpawner : IBulletSpawner
    {
        private Bullet prefab;
        private Transform worldTransform;
        private Transform container;
        private readonly Queue<Bullet> bulletPool = new();

        public BulletSpawner(Bullet prefab, Transform container, Transform worldTransform)
        {
            this.prefab = prefab;
            this.container = container;
            this.worldTransform = worldTransform;
        }

        public void CreateInstances(int items)
        {
            for (var i = 0; i < items; i++)
            {
                Bullet bullet = Object.Instantiate(prefab, container);
                bulletPool.Enqueue(bullet);
            }
        }

        public Bullet Spawn(Vector2 position, Color color, int physicsLayer, int damage, bool isPlayer,
            Vector2 velocity)
        {
            if (bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(worldTransform);
            }
            else
            {
                bullet = Object.Instantiate(prefab, worldTransform);
            }

            bullet.transform.position = position;
            bullet.spriteRenderer.color = color;
            bullet.gameObject.layer = physicsLayer;
            bullet.damage = damage;
            bullet.isPlayer = isPlayer;
            bullet.rigidbody2D.velocity = velocity;

            return bullet;
        }

        public void Recycle(Bullet bullet)
        {
            bullet.transform.SetParent(container);
            bulletPool.Enqueue(bullet);
        }
    }
}