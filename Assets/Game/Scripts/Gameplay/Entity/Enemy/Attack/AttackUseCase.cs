using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public static class AttackUseCase
    {
        public static void Attack(this IEntity entity, in IEntity target, in Cooldown cooldown, in float attackRange,
            in float deltaTime)
        {
            if (target == null)
                return;
            
            if (entity.TryGetAttackCondition(out var condition) && !condition.Invoke())
                return;

            float distance = entity.GetDistance(target);
            bool shouldAttack = distance < attackRange;

            cooldown.Tick(deltaTime);

            if (shouldAttack && cooldown.IsExpired())
            {
                entity.GetAttackingEvent().Invoke();
                cooldown.Reset();
            }
        }
    }
}