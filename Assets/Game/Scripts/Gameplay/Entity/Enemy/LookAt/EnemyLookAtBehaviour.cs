using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class EnemyLookAtBehaviour : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            IEntity target = entity.GetTarget().Value;
            if (target == null)
                return;
            
            Vector3 direction = entity.GetLookAtDirection(target);
            entity.RotateTowards(direction, deltaTime);
        }
    }
}