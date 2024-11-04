using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
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
        private Ship player;

        [SerializeField]
        private Ship enemyPrefab;

        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private Transform container;

        [SerializeField]
        private BulletManager bulletManager;

        [SerializeField]
        private int ActiveEnemies = 7;

        [SerializeField]
        private int MaxEnemies = 25;

        private Spawner<Ship> spawner;
        private readonly HashSet<Ship> activeEnemies = new();

        private void Awake()
        {
            spawner = new Spawner<Ship>(enemyPrefab, container, worldTransform);
            spawner.CreateInstances(MaxEnemies);
        }

        private void Start()
        {
            StartCoroutine(ManageEnemySpawning());
        }

        private void FixedUpdate()
        {
            UpdateActiveEnemies();
        }

        private IEnumerator ManageEnemySpawning()
        {
            while (true)
            {
                if (activeEnemies.Count < ActiveEnemies)
                {
                    int enemiesToSpawn = ActiveEnemies - activeEnemies.Count;

                    for (int i = 0; i < enemiesToSpawn; i++)
                    {
                        SpawnEnemy();
                        yield return new WaitForSeconds(Random.Range(1, 2));
                    }
                }

                yield return null;
            }
        }

        private void SpawnEnemy()
        {
            Ship enemy = spawner.Spawn();
            Transform spawnPosition = GetRandomPoint(spawnPositions);

            enemy.transform.position = spawnPosition.position;
            enemy.GetComponent<EnemyAI>().SetRandomDestination(attackPositions);
            AddEnemyToActive(enemy, player);
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