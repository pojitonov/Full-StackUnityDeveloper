using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class MoveUseCase
    {
        public static void MoveTowards(this IEntity entity, in Vector3 direction, in float deltaTime)
        {
            if (entity.TryGetMoveCondition(out var condition) && !condition.Value)
                return;

            var transform = entity.GetTransform();
            var speed = entity.GetMoveSpeed();
            
            transform.position += direction * (speed.Value * deltaTime);
        }

        public static void MoveTowardsDirection(this IEntity entity, float deltaTime)
        {
            var direction = entity.GetMoveDirection();
            
            entity.MoveTowards(direction.Value, deltaTime);
        }
    }
}