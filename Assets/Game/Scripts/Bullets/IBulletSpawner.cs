using UnityEngine;

namespace ShootEmUp
{
    public interface IBulletSpawner
    {
        void CreateInstances(int items);

        Bullet Spawn(Vector2 position, Color color, int physicsLayer, int damage, bool isPlayer,
            Vector2 velocity);

        void Recycle(Bullet bullet);
    }
}