using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public class UnitDirectionSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<UnitDirection> _directions;
        private readonly EcsPoolInject<Target> _targets;
        private readonly EcsPoolInject<StoppingDistance> _stoppingDistances;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                if (_targets.Value.Get(entity).value < 0)
                    return;
                
                var position = _positions.Value.Get(entity).value;
                var stoppingDistance = _stoppingDistances.Value.Get(entity).value;
                var target = _targets.Value.Get(entity).value;
                var targetPosition = _positions.Value.Get(target).value;
                var direction = CalculateDirection(position, targetPosition, stoppingDistance);
                
                SetDirection(entity, direction);
            }
        }

        private float3 CalculateDirection(float3 position, float3 targetPosition, float stoppingDistance)
        {
            var direction = math.normalize(targetPosition - position);
            return math.distance(position, targetPosition) > stoppingDistance ? direction : float3.zero;
        }

        private void SetDirection(int entity, float3 direction)
        {
            ref var unitDirection = ref _directions.Value.Get(entity);
            unitDirection.value = direction;
        }
    }
}