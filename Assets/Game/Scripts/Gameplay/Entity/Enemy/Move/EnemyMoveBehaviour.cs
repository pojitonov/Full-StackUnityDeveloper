using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class EnemyMoveBehaviour : IEntityUpdate
    {
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            if (!entity.HasTarget())
                return;

            var target = entity.GetTarget();
            entity.MoveTowardsPosition(target, deltaTime);
        }
    }
}