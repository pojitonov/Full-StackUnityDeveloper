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
            var direction = entity.GetDirection(target);
            entity.RotateTowards(direction, deltaTime);
        }

        public static void RotateTowards(this IEntity entity, in Quaternion targetRotation, in float deltaTime)
        {
            var speed = entity.GetAngularSpeed().Value * deltaTime;
            var transform = entity.GetTransform();
            transform.rotation = RotateTowards(transform.rotation, targetRotation, speed);
        }

        public static Quaternion RotateTowards(in Quaternion currentRotation, in Quaternion targetRotation,
            in float speed)
        {
            return Quaternion.Lerp(currentRotation, targetRotation, speed);
        }
    }
}