using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class VectorUseCase
    {
        public static Vector3 GetDirectionAt(this IEntity entity, in IEntity target)
        {
            Vector3 currentPosition = entity.GetTransform().position;
            Vector3 targetPosition = target.GetTransform().position;
            Vector3 vectorToTarget = targetPosition - currentPosition;
            vectorToTarget.y = 0;

            return vectorToTarget.normalized;
        }
    }
}