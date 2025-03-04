using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class SpawnSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<SpawnRequest> _requests;
        private readonly EcsUseCaseInject<SpawnUseCase> _spawnUseCase;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            while (_requests.Value.Consume(out SpawnRequest request))
                _spawnUseCase.Value.Spawn(request.prefab, request.position, request.rotation, request.team);
        }
    }
}