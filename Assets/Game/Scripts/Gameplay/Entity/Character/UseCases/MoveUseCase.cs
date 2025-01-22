using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class MoveUseCase
    {
        public static void MoveTowards(this IEntity entity, in Vector3 direction, in float deltaTime)
        {
            Transform transform = entity.GetTransform();
            float speed = entity.GetMoveSpeed();
            transform.position += direction * (deltaTime * speed);
        }
    }
}