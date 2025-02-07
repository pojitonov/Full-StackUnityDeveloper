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

        public static bool TakeDamage(this IEntity target, in DamageArgs args)
        {
            var health = target.GetHealth();
            var currentHealth = health.GetCurrent();
            
            if (!target.HasDamageableTag())
                return false;
            
            if (currentHealth < 0)
                return false;
            
            health.Reduce(args.damage);
            target.GetTakeDamageEvent().Invoke(args);
            return true;
        }

        public static bool AddHealth(this IEntity target, in int amount)
        {
            var health = target.GetHealth();
            var maxHealth = health.GetMax();
            var currentHealth = health.GetCurrent();
            
            if (target == null)
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