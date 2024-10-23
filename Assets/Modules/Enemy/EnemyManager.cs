using System.Collections;
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

        private readonly int enemyToSpawn = 5;
        private IEnemySpawner enemySpawner;
        private IEnemyFireHandler enemyFireHandler;
        private IEnemyPositioning enemyPositioning;
        private IEnemyLifecycleHandler _enemyLifecycleHandler;

        private void Awake()
        {
            enemySpawner = new EnemySpawner(prefab, container, worldTransform);
            enemySpawner.CreateInstances(enemyToSpawn);
            enemyFireHandler = new EnemyFireHandler(bulletManager);
            enemyPositioning = new EnemyPositioning();
            _enemyLifecycleHandler = new EnemyLifecycleHandler(enemySpawner, enemyFireHandler);
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(1, 2));

                Enemy enemy = enemySpawner.GetEnemy();

                Transform spawnPosition = enemyPositioning.GetRandomPoints(spawnPositions);
                enemy.transform.position = spawnPosition.position;

                Transform attackPosition = enemyPositioning.GetRandomPoints(attackPositions);
                enemy.SetDestination(attackPosition.position);
                
                _enemyLifecycleHandler.AddEnemy(enemy, player);
            }
        }

        private void FixedUpdate()
        {
            _enemyLifecycleHandler.UpdateEnemies();
        }
    }
}