using Atomic.Entities;

namespace Game.Gameplay
{
    public static class HealthUseCase
    {
        public static bool IsAlive(this IEntity entity)
        {
            var health = entity.GetHealth();
            return health.GetCurrent() > 0;
        }

        public static bool TakeDamage(this IEntity entity, in DamageArgs args)
        {
            var health = entity.GetHealth();
            var currentHealth = health.GetCurrent();
            
            if (!entity.HasDamageableTag())
                return false;
            
            if (currentHealth < 0)
                return false;
            
            health.Reduce(args.damage);
            entity.GetTakeDamageEvent().Invoke(args);
            return true;
        }

        public static bool AddHealth(this IEntity entity, in int amount)
        {
            var health = entity.GetHealth();
            var maxHealth = health.GetMax();
            var currentHealth = health.GetCurrent();
            
            if (entity == null)
                return false;

            if (currentHealth < 0)
                return false;

            if (currentHealth == maxHealth)
                return false;

            health.Add(amount);
            return true;
        }
    }
}