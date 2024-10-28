using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly Transform worldTransform;
        private readonly Transform container;
        private readonly Enemy prefab;
        private readonly Queue<Enemy> enemyPool = new();


        public EnemySpawner(Enemy prefab, Transform container, Transform worldTransform)
        {
            this.prefab = prefab;
            this.container = container;
            this.worldTransform = worldTransform;
        }

        public void CreateInstances(int items)
        {
            for (var i = 0; i < items; i++)
            {
                Enemy enemy = Object.Instantiate(prefab, container);
                enemyPool.Enqueue(enemy);
            }
        }

        public Enemy GetEnemy()
        {
            if (!enemyPool.TryDequeue(out Enemy enemy))
            {
                enemy = Object.Instantiate(this.prefab, this.container);
            }

            enemy.transform.SetParent(worldTransform);
            return enemy;
        }

        public void Recycle(Enemy enemy)
        {
            enemy.transform.SetParent(container);
            enemyPool.Enqueue(enemy);

        }
    }
}