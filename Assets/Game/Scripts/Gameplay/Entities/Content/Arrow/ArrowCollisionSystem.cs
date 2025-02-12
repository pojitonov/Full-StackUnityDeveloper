using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class ArrowCollisionSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<ArrowCollisionRequest> _requests;
        private readonly EcsUseCaseInject<ArrowCollisionUseCase> _useCase;
        
        public void Run(IEcsSystems systems)
        {
            while (_requests.Value.Consume(out var request))
                _useCase.Value.Collide(request.prefab, request.target);
        }
    }
}