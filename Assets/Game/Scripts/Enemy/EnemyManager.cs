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

        [SerializeField]
        private Ship enemyPrefab;

        [SerializeField]
        private Ship player;

        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private Transform container;

        [SerializeField]
        private int MaxEnemies = 25;

        private Spawner<Ship> spawner;
        private readonly HashSet<Ship> activeEnemies = new();
        private readonly EnemySpawner _enemySpawner;

        public void Awake()
        {
            spawner = new Spawner<Ship>(enemyPrefab, container, worldTransform);
            spawner.CreateInstances(MaxEnemies);
        }

        private void FixedUpdate()
        {
            UpdateActiveEnemies();
        }

        public void SpawnEnemy()
        {
            Ship enemy = spawner.Spawn();
            Transform spawnPosition = GetRandomPoint(spawnPositions);

            enemy.transform.position = spawnPosition.position;
            enemy.GetComponent<EnemyController>().SetDestination(attackPositions);
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
            enemy.GetComponent<EnemyController>().SetTarget(player);
            activeEnemies.Add(enemy);
        }

        private void UpdateActiveEnemies()
        {
            foreach (Ship enemy in activeEnemies.ToArray())
            {
                if (enemy.HealthComponent.Health <= 0)
                {
                    spawner.Recycle(enemy);
                    activeEnemies.Remove(enemy);
                }
            }
        }
    }
}