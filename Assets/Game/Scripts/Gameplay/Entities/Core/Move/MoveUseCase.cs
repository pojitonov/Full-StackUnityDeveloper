using Leopotam.EcsLite.Di;
using Unity.Burst;
using Unity.Mathematics;

namespace SampleGame
{
    [BurstCompile]
    public readonly struct MoveUseCase
    {
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<MoveEnabled> _moveEnables;
        private readonly EcsPoolInject<MoveDirection> _moveDirections;
        private readonly EcsPoolInject<MoveSpeed> _moveSpeeds;

        public void SetEnabled(in int entity, in bool value)
        {
            bool hasTag = _moveEnables.Value.Has(entity);

            if (!hasTag && value)
                _moveEnables.Value.Add(entity);

            if (hasTag && !value)
                _moveEnables.Value.Del(entity);
        }

        public void SetDirection(in int entity, in float3 direction)
        {
            _moveDirections.Value.Get(entity).value = direction;
        }

        public bool IsMoving(in int entity)
        {
            if (!_moveEnables.Value.Has(entity))
                return false;

            ref float3 direction = ref _moveDirections.Value.Get(entity).value;
            return math.any(direction != float3.zero);
        }

        public void MoveStep(in int entity, in float deltaTime)
        {
            ref Position position = ref _positions.Value.Get(entity);
            ref MoveDirection moveDirection = ref _moveDirections.Value.Get(entity);
            ref MoveSpeed moveSpeed = ref _moveSpeeds.Value.Get(entity);
            MoveStep(ref position, in moveDirection, in moveSpeed, in deltaTime);
        }

        [BurstCompile]
        public static void MoveStep(
            ref Position position,
            in MoveDirection moveDirection,
            in MoveSpeed moveSpeed,
            in float deltaTime
        )
        {
            position.value += moveDirection.value * moveSpeed.value * deltaTime;
        }
    }
}