using System.Collections.Generic;
using System.Linq;

namespace ShootEmUp
{
    public class EnemyLifecycleHandler : IEnemyLifecycleHandler
    {
        private readonly HashSet<Enemy> activeEnemies = new();
        private readonly IEnemySpawner enemySpawner;
        private readonly IEnemyFireHandler enemyFireHandler;
        
        public EnemyLifecycleHandler(IEnemySpawner enemySpawner, IEnemyFireHandler enemyFireHandler)
        {
            this.enemySpawner = enemySpawner;
            this.enemyFireHandler = enemyFireHandler;
        }

        public void AddEnemy(Enemy enemy, Player player)
        {
            enemy.target = player;

            if (activeEnemies.Count < 5 && activeEnemies.Add(enemy))
            {
                enemy.SubscribeToOnFire(enemyFireHandler.OnFire);
            }
        }

        public void UpdateEnemies()
        {
            foreach (Enemy enemy in activeEnemies.ToArray())
            {
                if (enemy.health <= 0)
                {
                    enemy.UnsubscribeFromOnFire(enemyFireHandler.OnFire);
                    enemySpawner.Recycle(enemy);
                    activeEnemies.Remove(enemy);
                }
            }
        }
    }
}