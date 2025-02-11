using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class SpawnSystemBase : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SpawnRequest>> _spawnRequests = EcsConsts.EventWorld;
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Rotation> _rotations;
        private readonly EcsPoolInject<TeamType> _teams;

        public void Run(IEcsSystems systems)
        {
            EcsWorld world = _world.Value;
            foreach (int evt in _spawnRequests.Value)
            {
                ref SpawnRequest request = ref _spawnRequests.Pools.Inc1.Get(evt);
              
                int entity = request.prefab.Create(world);
                _positions.Value.Add(entity).value = request.position;
                _rotations.Value.Add(entity).value = request.rotation;
                _teams.Value.Add(entity) = request.team;
                
                _spawnRequests.Pools.Inc1.Del(evt);
            }
        }
    }
}