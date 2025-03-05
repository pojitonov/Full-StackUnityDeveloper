using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class UnitRotateSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<RotateDirection> _rotationDirections;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsUseCaseInject<RotateUseCase> _rotateUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _units.Value)
            {
                bool healthExists = _healthUseCase.Value.Exists(entity);
                _rotateUseCase.Value.SetEnabled(entity, healthExists);

                if (_rotationDirections.Value.Has(entity))
                {
                    ref var rotationDirection = ref _rotationDirections.Value.Get(entity);
                    _rotateUseCase.Value.SetDirection(entity, rotationDirection.value);
                }
            }
        }
    }
}