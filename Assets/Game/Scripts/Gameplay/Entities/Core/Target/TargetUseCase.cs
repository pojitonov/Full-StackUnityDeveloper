using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public readonly struct TargetUseCase
    {
        private readonly EcsPoolInject<Radius> _radii;

        public float3 AdjustTargetPosition(float3 position, float3 targetPosition, int targetEntity)
        {
            if (_radii.Value.Has(targetEntity))
            {
                var targetRadius = _radii.Value.Get(targetEntity).value;
                var direction = math.normalize(targetPosition - position);
                return targetPosition - direction * targetRadius;
            }

            return targetPosition;
        }
    }
}