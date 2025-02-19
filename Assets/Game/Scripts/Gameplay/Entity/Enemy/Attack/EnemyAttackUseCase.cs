using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public static class EnemyAttackUseCase
    {
        public static void Attack(IEntity entity, float deltaTime, float stoppingDistance, Cooldown cooldown)
        {
            if (entity == null)
                return;

            var target = entity.GetTarget();
            var distance = entity.GetDistance(target);

            if (distance < stoppingDistance)
            {
                cooldown.Tick(deltaTime);

                if (cooldown.IsExpired())
                    return;
                
                cooldown.Reset();
                entity.GetAttackAction().Invoke();
            }
        }
    }
}