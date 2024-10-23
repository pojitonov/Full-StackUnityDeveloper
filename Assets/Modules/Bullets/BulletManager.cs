using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletManager : MonoBehaviour
    {
        [SerializeField]
        public Bullet prefab;

        [SerializeField]
        public Transform worldTransform;

        [SerializeField]
        private LevelBounds levelBounds;

        [SerializeField]
        private Transform container;

        private readonly int bulletsToSpawn = 10;
        private IBulletSpawner bulletSpawner;
        private IBulletDamageHandler bulletDamageHandler;

        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> cache = new();

        private void Awake()
        {
            bulletSpawner = new BulletSpawner(prefab, container, worldTransform);
            bulletDamageHandler = new BulletDamageHandler();
            bulletSpawner.CreateInstances(bulletsToSpawn);
        }

        private void FixedUpdate()
        {
            cache.Clear();
            cache.AddRange(activeBullets);

            for (int i = 0, count = cache.Count; i < count; i++)
            {
                Bullet bullet = cache[i];
                if (!levelBounds.InBounds(bullet.transform.position))
                {
                    RecycleBullet(bullet);
                }
            }
        }

        public void SpawnBullet(Vector2 position, Color color, int physicsLayer, int damage, bool isPlayer,
            Vector2 velocity)
        {
            Bullet bullet = bulletSpawner.Spawn(position, color, physicsLayer, damage, isPlayer, velocity);

            if (activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void RecycleBullet(Bullet bullet)
        {
            if (activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                bulletSpawner.Recycle(bullet);
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            bulletDamageHandler.HandleCollision(bullet, collision);
            RecycleBullet(bullet);
        }
    }
}