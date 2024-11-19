using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletManager : MonoBehaviour
    {
        [SerializeField]
        private Bullet bulletPrefab;

        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private LevelBounds levelBounds;

        [SerializeField]
        private Transform container;

        [SerializeField]
        private int maxBullets = 10;

        private Spawner<Bullet> spawner;
        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> cache = new();

        private void Awake()
        {
            spawner = new Spawner<Bullet>(bulletPrefab, container, worldTransform);
            spawner.CreateInstances(maxBullets);
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

        public void SpawnBullet(Vector2 position, int damage, bool isPlayer, Vector2 velocity, Color color,
            int physicsLayer)
        {
            Bullet bullet = spawner.Spawn();
            bullet.Initialize(position, color, physicsLayer, damage, isPlayer, velocity);

            if (activeBullets.Add(bullet))
            {
                bullet.OnCompleted += RecycleBullet;
            }
        }

        private void RecycleBullet(Bullet bullet)
        {
            if (activeBullets.Remove(bullet))
            {
                bullet.OnCompleted -= RecycleBullet;
                spawner.Recycle(bullet);
            }
        }
    }
}