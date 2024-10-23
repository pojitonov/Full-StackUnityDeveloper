namespace ShootEmUp
{
    public interface IEnemyLifecycleHandler
    {
        void AddEnemy(Enemy enemy, Player player);
        void UpdateEnemies();
    }
}