using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class EnemyRotateBehaviour : IEntityUpdate
    {
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            if (!entity.HasTarget()) return;
            
            var target = entity.GetTarget();
            if (target == null) return;
            
            entity.RotateTowardsTarget(target, deltaTime);
        }
    }
}