using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class MoveUseCase
    {
        public static void MoveTowardsDirection(this IEntity entity, float deltaTime)
        {
            var direction = entity.GetMoveDirection();
            entity.MoveTowards(direction.Value, deltaTime);
        }

        public static void MoveTowards(this IEntity entity, in Vector3 direction, float deltaTime)
        {
            if (entity.TryGetMoveCondition(out var condition) && !condition.Value)
                return;

            Transform transform = entity.GetTransform();
            IValue<float> speed = entity.GetMoveSpeed();
            transform.position += direction * (speed.Invoke() * deltaTime);
        }
    }
}