using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public readonly struct UnitDirectionUseCase
    {
        private readonly EcsPoolInject<Radius> _radii;
        private readonly EcsPoolInject<UnitDirection> _directions;
        private readonly EcsPoolInject<RotateDirection> _rotationDirections;

        public float3 CalculateDirection(float3 position, float3 targetPosition, float stoppingDistance, int targetEntity)
        {
            float unitRadius = 0f;
            if (_radii.Value.Has(targetEntity)) 
                unitRadius = _radii.Value.Get(targetEntity).value;

            var direction = math.normalize(targetPosition - position);
            var adjustedTargetPosition = targetPosition - direction * unitRadius;
            var distanceToAdjustedTarget = math.distance(position, adjustedTargetPosition);
            return distanceToAdjustedTarget > stoppingDistance ? direction : float3.zero;
        }

        public void SetDirection(int entity, float3 direction)
        {
            ref var unitDirection = ref _directions.Value.Get(entity);
            unitDirection.value = direction;
        }

        public void SetRotationDirection(int entity, float3 rotationDirection)
        {
            if (!_rotationDirections.Value.Has(entity))
                _rotationDirections.Value.Add(entity);

            ref var rotationDir = ref _rotationDirections.Value.Get(entity);
            rotationDir.value = rotationDirection;
        }
    }
}