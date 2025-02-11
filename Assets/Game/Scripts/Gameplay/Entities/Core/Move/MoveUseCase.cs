using Unity.Burst;

namespace SampleGame
{
    [BurstCompile]
    public static class MoveUseCase
    {
        public static void MoveStep(ref Position position, in MoveDirection moveDirection, in MoveSpeed moveSpeed,
            in float deltaTime)
        {
            position.value += moveDirection.value * moveSpeed.value * deltaTime;
        }
    }
}