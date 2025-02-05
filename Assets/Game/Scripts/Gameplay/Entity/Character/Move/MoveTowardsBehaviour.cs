using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class MoveTowardsBehaviour : IEntityUpdate
    {
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            entity.MoveTowardsDirection(deltaTime);
        }
    }
}