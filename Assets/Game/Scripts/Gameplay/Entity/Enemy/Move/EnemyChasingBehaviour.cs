using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class EnemyChasingBehaviour : IEntityUpdate
    {
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            if (!entity.GetIsChasing().Value) return;

            var target = entity.GetTarget();
            if (target == null) return;

            entity.MoveTowardsPosition(target, deltaTime);
        }
    }
}