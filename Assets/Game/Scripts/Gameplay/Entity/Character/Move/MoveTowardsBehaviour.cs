using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class MoveTowardsBehaviour : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            entity.MoveTowardsDirection(deltaTime);
        }
    }
}