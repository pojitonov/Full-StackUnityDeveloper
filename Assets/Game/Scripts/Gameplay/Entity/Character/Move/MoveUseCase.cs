using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class MoveUseCase
    {
        private const float STOPPING_OFFSET = 0.8f;

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
            entity.MoveTowards(entity.GetMoveDirection().Value, deltaTime);
        }

        public static void MoveTowardsPosition(this IEntity entity, in Vector3 targetPosition, in float deltaTime)
        {
            var direction = GetDirectionWithStoppingOffset(entity, targetPosition);
            entity.MoveTowards(direction, deltaTime);
        }

        public static void MoveTowardsPosition(this IEntity entity, in IEntity target, in float deltaTime)
        {
            MoveTowardsPosition(entity, target.GetTransform().position, deltaTime);
        }

        private static Vector3 GetDirectionWithStoppingOffset(IEntity entity, Vector3 targetPosition)
        {
            var currentPosition = entity.GetTransform().position;
            var direction = (targetPosition - currentPosition).normalized;
            var distance = Vector3.Distance(currentPosition, targetPosition);

            return distance > STOPPING_OFFSET ? direction : Vector3.zero;
        }
    }
}