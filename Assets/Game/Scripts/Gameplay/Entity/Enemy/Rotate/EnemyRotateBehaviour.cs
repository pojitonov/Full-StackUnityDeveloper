using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class EnemyRotateBehaviour : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            IEntity target = entity.GetTarget().Value;
            if (target == null)
                return;
            
            entity.RotateTowardsTarget(target, deltaTime);
        }
    }
}