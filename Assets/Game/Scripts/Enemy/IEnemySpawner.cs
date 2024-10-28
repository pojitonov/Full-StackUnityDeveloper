namespace ShootEmUp
{
    public interface IEnemySpawner
    {
        void CreateInstances(int items);
        Enemy GetEnemy();
        void Recycle(Enemy enemy);
    }
}