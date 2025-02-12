using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class DestroySystem : IEcsRunSystem
    {
        private readonly EcsEventInject<DestroyRequest> _destroyRequests;
        private readonly EcsWorldInject _world;

        public void Run(IEcsSystems systems)
        {
            while (_destroyRequests.Value.Consume(out var request)) 
                _world.Value.DelEntity(request.entity);
        }
    }
}