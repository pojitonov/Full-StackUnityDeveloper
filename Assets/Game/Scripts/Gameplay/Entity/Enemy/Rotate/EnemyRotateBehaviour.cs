using Atomic.Entities;

namespace Game.Gameplay
{
    public class EnemyRotateBehaviour : IEntityUpdate
    {
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            if (!entity.GetChasing().Value) return;

            IEntity target = entity.GetTarget();
            if (target == null) return;
            
            entity.RotateTowardsTarget(target, deltaTime);
        }
    }
}