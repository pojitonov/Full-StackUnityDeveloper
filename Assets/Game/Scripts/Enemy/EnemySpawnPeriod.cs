using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawnController  : MonoBehaviour
    {
        [SerializeField]
        private FloatRange waitTimeRange;
        
        [SerializeField]
        private EnemyManager enemyManager;

        [SerializeField]
        private int MaxEnemies = 25;
        
        [SerializeField]
        private int ActiveEnemies = 7;
        
        [SerializeField]
        private Ship enemyPrefab;

        [SerializeField]
        private Ship player;
        
        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private Transform container;


        private void Start()
        {
            enemyManager.Initialize(enemyPrefab, player, container, worldTransform, MaxEnemies);
            StartCoroutine(ManageEnemySpawning());
        }

        public IEnumerator ManageEnemySpawning()
        {
            while (true)
            {
                if (enemyManager.GetActiveEnemiesCount() < ActiveEnemies)
                {
                    int enemiesToSpawn = ActiveEnemies - enemyManager.GetActiveEnemiesCount();

                    for (int i = 0; i < enemiesToSpawn; i++)
                    {
                        enemyManager.SpawnEnemy();
                        yield return new WaitForSeconds(waitTimeRange.GetRandomValue());
                    }
                }

                yield return null;
            }
        }
    }
}