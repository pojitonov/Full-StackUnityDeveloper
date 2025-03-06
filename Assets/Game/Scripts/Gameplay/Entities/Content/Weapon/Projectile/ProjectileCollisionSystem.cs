using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class ProjectileCollisionSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<ProjectileCollisionRequest> _collisionRequests;
        private readonly EcsUseCaseInject<ProjectileCollisionUseCase> _collisionUseCase;
        
        public void Run(IEcsSystems systems)
        {
            while (_collisionRequests.Value.Consume(out ProjectileCollisionRequest request))
                _collisionUseCase.Value.Collide(request.projectile, request.target);
        }
    }
}