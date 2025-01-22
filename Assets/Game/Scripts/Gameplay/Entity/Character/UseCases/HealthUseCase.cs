using Atomic.Entities;

namespace Game.Gameplay
{
    public static class HealthUseCase
    {
        public static bool IsAlive(this IEntity entity)
        {
            return entity.GetHealth().Value > 0;
        }
    }
}