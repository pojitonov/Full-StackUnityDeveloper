using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class RotateUseCase
    {
        public static void RotateTowards(IEntity entity, in Vector3 direction, in float deltaTime)
        {
            if (direction == Vector3.zero)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            RotateTowards(entity, targetRotation, deltaTime);
        }

        public static void RotateTowards(IEntity entity, in Quaternion targetRotation, in float deltaTime)
        {
            float speed = entity.GetValue<float>("RotationSpeed");
            Transform transform = entity.GetValue<Transform>("Transform");
            transform.rotation = RotateTowards(transform.rotation, targetRotation, speed);
        }

        public static Quaternion RotateTowards(in Quaternion currentRotation, in Quaternion targetRotation,
            in float speed)
        {
            return Quaternion.Lerp(currentRotation, targetRotation, speed);
        }
    }
}