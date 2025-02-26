using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class DeathSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DeathTag>> _deathables;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsEventInject<DespawnRequest> _despawnRequest;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _deathables.Value)
                if (!_healthUseCase.Value.Exists(entity))
                    _despawnRequest.Value.Fire(new DespawnRequest {entity = entity});
        }
    }
}