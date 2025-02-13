using Leopotam.EcsLite.Di;
using Unity.Burst;
using Unity.Mathematics;

namespace SampleGame
{
    [BurstCompile]
    public readonly struct RotateUseCase
    {
        private static readonly float3 UP = new(0, 1, 0);

        private readonly EcsPoolInject<RotationEnabled> _rotateEnables;
        private readonly EcsPoolInject<Rotation> _rotations;
        private readonly EcsPoolInject<RotationSpeed> _rotationSpeeds;
        private readonly EcsPoolInject<RotateDirection> _rotationDirections;

        public void SetEnabled(in int entity, in bool value)
        {
            bool hasTag = _rotateEnables.Value.Has(entity);

            if (value && !hasTag)
                _rotateEnables.Value.Add(entity);
            else if (!value && hasTag)
                _rotateEnables.Value.Del(entity);
        }

        public void SetDirection(in int entity, in float3 direction)
        {
            _rotationDirections.Value.Get(entity).value = direction;
        }

        public void RotateStep(in int entity, in float deltaTime)
        {
            ref Rotation rotation = ref _rotations.Value.Get(entity);
            ref RotationSpeed speed = ref _rotationSpeeds.Value.Get(entity);
            ref RotateDirection direction = ref _rotationDirections.Value.Get(entity);
            RotateStep(ref rotation, in direction, in speed, in deltaTime);
        }

        [BurstCompile]
        public static void RotateStep(
            ref Rotation rotation,
            in RotateDirection direction,
            in RotationSpeed speed,
            in float deltaTime
        )
        {
            if (math.all(direction.value == float3.zero))
                return;

            quaternion target = quaternion.LookRotation(direction.value, UP);
            rotation.value = math.slerp(rotation.value, target, speed.value * deltaTime);
        }
    }
}