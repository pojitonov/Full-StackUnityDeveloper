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
        private Ship playerPrefab;

        [SerializeField]
        private Ship enemyPrefab;
        
        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private Transform container;

        [SerializeField]
        private BulletManager bulletManager;

        private readonly int objToSpawn = 5;
        private Spawner<Ship> spawner;
        private readonly HashSet<Ship> activeEnemies = new();

        private void Awake()
        {
            spawner = new Spawner<Ship>(enemyPrefab, container, worldTransform);
            spawner.CreateInstances(objToSpawn);
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(1, 2));

                if (activeEnemies.Count >= objToSpawn) continue;

                Transform spawnPosition = GetRandomPoint(spawnPositions);
                Ship enemy = spawner.Spawn();
                enemy.transform.position = spawnPosition.position;
                enemy.GetComponent<EnemyAI>().SetRandomDestination(attackPositions);
                AddEnemyToActive(enemy, playerPrefab);
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