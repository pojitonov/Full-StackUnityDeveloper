using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class UnitMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<UnitDirection> _unitDirections;
        private readonly EcsUseCaseInject<MoveUseCase> _moveUseCase;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _units.Value)
            {
                bool healthExists = _healthUseCase.Value.Exists(entity);
                _moveUseCase.Value.SetEnabled(entity, healthExists);
                
                ref UnitDirection unitDirection = ref _unitDirections.Value.Get(entity);
                _moveUseCase.Value.SetDirection(entity, unitDirection.value);
            }
        }
    }
}