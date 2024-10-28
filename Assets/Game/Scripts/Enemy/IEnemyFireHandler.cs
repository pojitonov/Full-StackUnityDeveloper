using UnityEngine;

namespace ShootEmUp
{
    public interface IEnemyFireHandler
    {
        void OnFire(Vector2 position, Vector2 direction);
    }
}