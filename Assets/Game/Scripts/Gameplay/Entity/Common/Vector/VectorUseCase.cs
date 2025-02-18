using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class VectorUseCase
    {
        public static Vector3 GetDirection(this IEntity entity, in IEntity target)
        {
            if (entity == null || target == null || !entity.TryGetTransform(out var currentTransform) ||
                !target.TryGetTransform(out var targetTransform))
                return Vector3.zero;

            Vector3 currentPosition = currentTransform.position;
            Vector3 targetPosition = targetTransform.position;
            Vector3 vectorToTarget = targetPosition - currentPosition;

            vectorToTarget.y = 0;
            return vectorToTarget.normalized;
        }

        public static float GetDistance(this IEntity entity, in IEntity target)
        {
            if (entity == null || target == null || !entity.TryGetTransform(out var currentTransform) ||
                !target.TryGetTransform(out var targetTransform))
                return float.MaxValue;

            Vector3 currentPosition = currentTransform.position;
            Vector3 targetPosition = targetTransform.position;

            float distance = Vector3.Distance(currentPosition, targetPosition);
            return distance;
        }
    }
}