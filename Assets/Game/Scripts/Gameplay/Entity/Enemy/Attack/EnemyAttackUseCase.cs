using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public static class EnemyAttackUseCase
    {
        public static bool CanAttack(this IEntity entity, in float stoppingDistance, in Cooldown cooldown)
        {
            var target = entity.GetTarget();
            var distance = entity.GetDistance(target);
            
            if (distance < stoppingDistance && cooldown.IsExpired())
            {
                return true;
            }

            return false;
        }
    }
}