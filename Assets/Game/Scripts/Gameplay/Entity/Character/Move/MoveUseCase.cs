using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class MoveUseCase
    {
        public static void MoveTowards(this IEntity entity, in Vector3 direction, in float deltaTime)
        {
            if (entity.TryGetMoveCondition(out var condition) && !condition.Value)
            {
                entity.GetMoveDirection().Value = Vector3.zero;
                return;
            }

            var transform = entity.GetTransform();
            var speed = entity.GetMoveSpeed();

            transform.position += direction * (speed.Value * deltaTime);
            entity.GetMoveDirection().Value = direction;
        }

        public static void MoveTowardsDirection(this IEntity entity, float deltaTime)
        {
            var direction = entity.GetMoveDirection();
            
            entity.MoveTowards(direction.Value, deltaTime);
        }

        public static void MoveTowardsPosition(this IEntity entity, in Vector3 targetPosition, in float deltaTime)
        {
            var currentPosition = entity.GetTransform().position;
            var direction = (targetPosition - currentPosition).normalized;
            
            entity.MoveTowards(direction, deltaTime);
        }

        public static void MoveTowardsPosition(this IEntity entity, in IEntity target, in float deltaTime)
        {
            entity.MoveTowardsPosition(target.GetTransform().position, deltaTime);

        }
    }
}