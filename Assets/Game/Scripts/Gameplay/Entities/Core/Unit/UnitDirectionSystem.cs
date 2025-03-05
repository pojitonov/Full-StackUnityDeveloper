using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public class UnitDirectionSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<Target> _targets;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<UnitDirection> _directions;
        private readonly EcsPoolInject<StoppingDistance> _stoppingDistances;
        private readonly EcsUseCaseInject<UnitDirectionUseCase> _directionUseCase;

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

                var direction = _directionUseCase.Value.CalculateDirection(position, targetPosition, stoppingDistance, targetEntity);

                _directionUseCase.Value.SetDirection(entity, direction);
            }
        }
    }
}