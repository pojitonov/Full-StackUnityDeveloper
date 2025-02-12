using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class DeathSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DeathTag>> _entities;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsEventInject<DestroyRequest> _destroyRequest;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _entities.Value)
                if (!_healthUseCase.Value.Exists(entity))
                    _destroyRequest.Value.Fire(new DestroyRequest {entity = entity});
        }
    }
}