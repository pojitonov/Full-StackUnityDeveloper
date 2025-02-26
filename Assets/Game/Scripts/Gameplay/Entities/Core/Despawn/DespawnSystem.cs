using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class DespawnSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world;
        private readonly EcsEventInject<DespawnRequest> _despawnRequests;

        public void Run(IEcsSystems systems)
        {
            while (_despawnRequests.Value.Consume(out DespawnRequest request)) 
                _world.Value.DelEntity(request.entity);
        }
    }
}