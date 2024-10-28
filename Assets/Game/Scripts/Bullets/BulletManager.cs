using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletManager : MonoBehaviour
    {
        [SerializeField]
        private Bullet prefab;

        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private LevelBounds levelBounds;

        [SerializeField]
        private Transform container;

        private readonly int bulletsToSpawn = 10;
        private IBulletSpawner bulletSpawner;
        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> cache = new();

        private void Awake()
        {
            bulletSpawner = new BulletSpawner(prefab, container, worldTransform);
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

        public void SpawnBullet(Vector2 position, Color color, int physicsLayer, int damage, bool isPlayer, Vector2 velocity)
        {
            Bullet bullet = bulletSpawner.Spawn(position, color, physicsLayer, damage, isPlayer, velocity);

            if (activeBullets.Add(bullet))
            {
                bullet.OnWorkCompleted += RecycleBullet;
            }
        }

        private void RecycleBullet(Bullet bullet)
        {
            if (activeBullets.Remove(bullet))
            {
                bullet.OnWorkCompleted -= RecycleBullet;
                bulletSpawner.Recycle(bullet);
            }
        }
    }
}