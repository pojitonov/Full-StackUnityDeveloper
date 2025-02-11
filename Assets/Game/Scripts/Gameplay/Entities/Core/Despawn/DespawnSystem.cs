using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class DespawnSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<DespawnRequest> _despawnRequests;
        private readonly EcsWorldInject _world;

        public void Run(IEcsSystems systems)
        {
            while (_despawnRequests.Value.Consume(out DespawnRequest request)) 
                _world.Value.DelEntity(request.entity);
        }
    }
}