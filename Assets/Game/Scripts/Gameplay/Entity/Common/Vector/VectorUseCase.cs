using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class VectorUseCase
    {
        public static Vector3 GetDirection(this IEntity entity, in IEntity target)
        {
            if (!entity.HasTransform() || !target.HasTransform()) return Vector3.zero;
            
            Vector3 currentPosition = entity.GetTransform().position;
            Vector3 targetPosition = target.GetTransform().position;
            Vector3 vectorToTarget = targetPosition - currentPosition;
            vectorToTarget.y = 0;
            return vectorToTarget.normalized;
        }
        
        public static float GetDistance(this IEntity entity, in IEntity target)
        {
            Vector3 currentPosition = entity.GetTransform().position;
            Vector3 targetPosition = target.GetTransform().position;
            float distance = Vector3.Distance(currentPosition, targetPosition);
            return distance;
        }
    }
}