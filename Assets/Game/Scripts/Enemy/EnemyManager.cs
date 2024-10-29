using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private Transform[] spawnPositions;

        [SerializeField]
        private Transform[] attackPositions;

        [SerializeField]
        private Player player;

        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private Transform container;

        [SerializeField]
        private Enemy prefab;

        [SerializeField]
        private BulletManager bulletManager;

        private readonly int objToSpawn = 5;
        private Spawner<Enemy> spawner;
        private readonly HashSet<Enemy> activeEnemies = new();

        private void Awake()
        {
            spawner = new Spawner<Enemy>(prefab, container, worldTransform);
            spawner.CreateInstances(objToSpawn);
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(1, 2));

                if (activeEnemies.Count >= objToSpawn) continue;

                Transform spawnPosition = GetRandomPoint(spawnPositions);
                Enemy enemy = spawner.Spawn();
                enemy.transform.position = spawnPosition.position;
                enemy.SetRandomDestination(attackPositions);
                AddEnemyToActive(enemy, player);
            }
        }

        private void FixedUpdate()
        {
            UpdateActiveEnemies();
        }

        private Transform GetRandomPoint(Transform[] points)
        {
            int index = Random.Range(0, points.Length);
            return points[index];
        }
        
        private void AddEnemyToActive(Enemy enemy, Player player)
        {
            enemy.Target = player;
            activeEnemies.Add(enemy);
        }

        private void UpdateActiveEnemies()
        {
            foreach (Enemy enemy in activeEnemies.ToArray())
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