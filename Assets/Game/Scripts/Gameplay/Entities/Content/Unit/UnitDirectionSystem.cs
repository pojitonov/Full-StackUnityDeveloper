using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public class UnitDirectionSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<UnitDirection> _directions;
        private readonly EcsPoolInject<StoppingDistance> _stoppingDistances;
        private readonly EcsPoolInject<Target> _targets;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                ref var target = ref _targets.Value.Get(entity);
                if (!target.target.Unpack(_world.Value, out int targetEntity)) 
                    continue;

                var position = _positions.Value.Get(entity).value;
                var stoppingDistance = _stoppingDistances.Value.Get(entity).value;
                var targetPosition = _positions.Value.Get(targetEntity).value;
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