using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class RotateTowardsBehaviour : IEntityUpdate
    {
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            entity.RotateTowardsDirection(deltaTime);
        }
    }
}