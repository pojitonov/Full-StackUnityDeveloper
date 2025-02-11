using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class SpawnSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<SpawnRequest> _requests;
        private readonly EcsUseCaseInject<SpawnUseCase> _useCase;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            while (_requests.Value.Consume(out SpawnRequest request))
                _useCase.Value.Spawn(request.prefab, request.position, request.rotation, request.team);
        }
    }
}