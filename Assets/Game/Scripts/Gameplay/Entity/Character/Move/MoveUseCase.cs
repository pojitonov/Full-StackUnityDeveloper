using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class MoveUseCase
    {
        private const float STOPPING_OFFSET = 1f;

        public static void MoveTowards(this IEntity entity, in Vector3 direction, in float deltaTime)
        {
            if (!entity.CanMove() || direction == Vector3.zero)
            {
                entity.GetMoveDirection().Value = Vector3.zero;
                return;
            }

            var transform = entity.GetTransform();
            var speed = entity.GetMoveSpeed();

            transform.position += direction * (speed.Value * deltaTime);
            entity.GetMoveDirection().Value = direction;
        }

        public static void MoveTowardsDirection(this IEntity entity, float deltaTime) =>
            entity.MoveTowards(entity.GetMoveDirection().Value, deltaTime);

        public static void MoveTowardsPosition(this IEntity entity, in Vector3 targetPosition, in float deltaTime) =>
            entity.MoveTowards(GetDirectionWithStoppingOffset(entity, targetPosition), deltaTime);

        public static void MoveTowardsPosition(this IEntity entity, in IEntity target, in float deltaTime)
        {
            if (target?.HasTransform() != true)
            {
                entity.GetMoveDirection().Value = Vector3.zero;
                return;
            }

            MoveTowardsPosition(entity, target.GetTransform().position, deltaTime);
        }

        private static Vector3 GetDirectionWithStoppingOffset(IEntity entity, Vector3 targetPosition)
        {
            var currentPosition = entity.GetTransform().position;
            var distance = Vector3.Distance(currentPosition, targetPosition);

            return distance > STOPPING_OFFSET ? (targetPosition - currentPosition).normalized : Vector3.zero;
        }

        private static bool CanMove(this IEntity entity) =>
            entity.TryGetMoveCondition(out var condition) && condition.Value;
    }
}