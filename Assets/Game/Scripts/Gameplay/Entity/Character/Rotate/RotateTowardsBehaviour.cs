using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class RotateTowardsBehaviour : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            entity.RotateTowardsDirection(deltaTime);
        }
    }
}