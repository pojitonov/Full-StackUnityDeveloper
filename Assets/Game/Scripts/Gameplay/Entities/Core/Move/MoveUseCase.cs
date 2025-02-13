using Leopotam.EcsLite.Di;
using Unity.Burst;
using Unity.Mathematics;

namespace SampleGame
{
    [BurstCompile]
    public struct MoveUseCase
    {
        private readonly EcsPoolInject<MoveDirection> _moveDirections;
        
        public static void MoveStep(ref Position position, in MoveDirection moveDirection, in MoveSpeed moveSpeed,
            in float deltaTime)
        {
            position.value += moveDirection.value * moveSpeed.value * deltaTime;
        }
        
        public bool IsMoving(in int entity)
        {
            ref float3 direction = ref _moveDirections.Value.Get(entity).value;
            return math.any(direction != float3.zero);
        }
    }
}