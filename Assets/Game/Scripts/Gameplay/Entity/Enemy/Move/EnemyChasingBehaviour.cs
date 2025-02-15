using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class EnemyChasingBehaviour : IEntityUpdate
    {
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            if (!entity.GetChasing().Value) return;

            var target = entity.GetTarget();
            entity.MoveTowardsPosition(target, deltaTime);
        }
    }
}