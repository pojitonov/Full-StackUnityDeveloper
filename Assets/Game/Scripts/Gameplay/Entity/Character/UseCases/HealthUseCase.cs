using System;
using Atomic.Entities;

namespace Game.Gameplay
{
    public static class HealthUseCase
    {
        public static bool IsAlive(this IEntity entity)
        {
            return entity.GetHealth().Value > 0;
        }

        public static bool TakeDamage(this IEntity entity, in int damage)
        {
            if (!entity.HasDamageableTag())
                return false;
     
            var health = entity.GetHealth();
            
            if (health.Value < 0)
                return false;
            
            health.Value -= Math.Max(0, health.Value - damage);
            return true;
        }
    }
}