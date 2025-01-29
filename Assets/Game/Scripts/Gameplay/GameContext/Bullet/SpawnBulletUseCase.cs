using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class SpawnBulletUseCase
    {
        public static IEntity SpawnBullet(IGameContext context, in Vector3 position, in Quaternion rotation)
        {
            var bullet = context.GetBulletPool().Rent();
            var bulletTransform = bullet.GetTransform();
            
            bulletTransform.SetPositionAndRotation(position, rotation);
            bullet.GetLifetime().Reset();
            bullet.GetMoveDirection().Value = bulletTransform.forward;
            
            return bullet;
        }

        public static void UnspawnBullet(in IGameContext context, in IEntity bullet)
        {
            context.GetBulletPool().Return(bullet);
        }
    }
}