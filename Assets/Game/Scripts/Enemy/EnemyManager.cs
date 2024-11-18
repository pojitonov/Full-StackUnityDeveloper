using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private Transform[] spawnPositions;

        [SerializeField]
        private Transform[] attackPositions;

        private Spawner<Ship> spawner;
        private readonly HashSet<Ship> activeEnemies = new();
        private readonly EnemySpawnController enemySpawnController;
        private Ship player;

        private void FixedUpdate()
        {
            UpdateActiveEnemies();
        }

        public void Initialize(Ship enemyPrefab, Ship player, Transform container, Transform worldTransform, int maxEnemies)
        {
            spawner = new Spawner<Ship>(enemyPrefab, container, worldTransform);
            spawner.CreateInstances(maxEnemies);
            this.player = player;
        }

        public void SpawnEnemy()
        {
            Ship enemy = spawner.Spawn();
            Transform spawnPosition = GetRandomPoint(spawnPositions);

            enemy.transform.position = spawnPosition.position;
            enemy.GetComponent<EnemyAI>().SetRandomDestination(attackPositions);
            AddEnemyToActive(enemy, player);
        }

        public int GetActiveEnemiesCount()
        {
            return activeEnemies.Count;
        }

        private Transform GetRandomPoint(Transform[] points)
        {
            int index = Random.Range(0, points.Length);
            return points[index];
        }

        private void AddEnemyToActive(Ship enemy, Ship player)
        {
            enemy.GetComponent<EnemyAI>().Target = player;
            activeEnemies.Add(enemy);
        }

        private void UpdateActiveEnemies()
        {
            foreach (Ship enemy in activeEnemies.ToArray())
            {
                if (enemy.Health <= 0)
                {
                    spawner.Recycle(enemy);
                    activeEnemies.Remove(enemy);
                }
            }
        }
    }
}