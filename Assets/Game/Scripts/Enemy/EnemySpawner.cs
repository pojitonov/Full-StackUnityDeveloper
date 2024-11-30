using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private FloatRange waitTimeRange;

        [SerializeField]
        private EnemyManager enemyManager;

        [SerializeField]
        private int ActiveEnemies = 7;

        private void Start()
        {
            StartCoroutine(ControlEnemySpawning());
        }

        private IEnumerator ControlEnemySpawning()
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