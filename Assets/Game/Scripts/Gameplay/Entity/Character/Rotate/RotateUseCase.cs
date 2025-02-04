using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class RotateUseCase
    {
        public static void RotateTowards(this IEntity entity, in Vector3 direction, in float deltaTime)
        {
            if (entity.TryGetRotateCondition(out var condition) && !condition.Value)
                return;
            
            if (direction == Vector3.zero)
                return;

            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            entity.RotateTowards(targetRotation, deltaTime);
        }
        
        public static void RotateTowardsDirection(this IEntity entity, in float deltaTime)
        {
            var direction = entity.GetMoveDirection();
            
            entity.RotateTowards(direction.Value, deltaTime);
        }
        
        public static void RotateTowardsTarget(this IEntity entity, in IEntity target, in float deltaTime)
        {
            Vector3 direction = entity.GetLookAtDirection(target);
            entity.RotateTowards(direction, deltaTime);
        }

        public static void RotateTowards(this IEntity entity, in Quaternion targetRotation, in float deltaTime)
        {
            float speed = entity.GetAngularSpeed().Value * deltaTime;
            Transform transform = entity.GetTransform();
            transform.rotation = RotateTowards(transform.rotation, targetRotation, speed);
        }

        public static Quaternion RotateTowards(in Quaternion currentRotation, in Quaternion targetRotation,
            in float speed)
        {
            return Quaternion.Lerp(currentRotation, targetRotation, speed);
        }
        
        public static Vector3 GetLookAtDirection(this IEntity entity, in IEntity target)
        {
            Vector3 currentPosition = entity.GetTransform().position;
            Vector3 targetPosition = target.GetTransform().position;
            Vector3 vectorToTarget = targetPosition - currentPosition;
            vectorToTarget.y = 0;
            return vectorToTarget.normalized;
        }
    }
}