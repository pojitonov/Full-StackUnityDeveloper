using UnityEngine;

namespace ShootEmUp
{
    public interface IBulletDamageHandler
    {
        void HandleCollision(Bullet bullet, Collision2D collision);
    }
}