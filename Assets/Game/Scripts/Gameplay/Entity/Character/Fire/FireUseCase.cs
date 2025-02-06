using Atomic.Entities;

namespace Game.Gameplay
{
    public static class FireUseCase
    {
        public static IEntity FireBullet(this IWeaponEntity entity, in IGameContext context)
        {
            var firePoint = entity.GetTransform();
            var firePointPosition = firePoint.position;
            var firePointRotation = firePoint.rotation;
            return SpawnBulletUseCase.SpawnBullet(context, firePointPosition, firePointRotation);
        }
    }
}