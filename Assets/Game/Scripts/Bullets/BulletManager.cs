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

        private readonly int objToSpawn = 10;
        private Spawner<Bullet> spawner;
        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> cache = new();

        private void Awake()
        {
            spawner = new Spawner<Bullet>(prefab, container, worldTransform);
            spawner.CreateInstances(objToSpawn);
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