using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public class UnitFireSystem : IEcsRunSystem
    {
        private readonly EcsPrototype _arrowPrefab;
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<UnitFire> _unitFires;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Rotation> _rotations;
        private readonly EcsPoolInject<TeamType> _teamTypes;

        private readonly EcsWorldInject _eventWorld = EcsConsts.EventWorld;
        private readonly EcsPoolInject<ArrowSpawnRequest> _spawnRequests = EcsConsts.EventWorld;

        public UnitFireSystem(EcsPrototype arrowPrefab)
        {
            _arrowPrefab = arrowPrefab;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                ref var unitFires = ref _unitFires.Value.Get(entity);
                if (!unitFires.value)
                    continue;

                var spawnRequest = _eventWorld.Value.NewEntity();
                _spawnRequests.Value.Add(spawnRequest) = new ArrowSpawnRequest
                {
                    prefab = _arrowPrefab,
                    position = _positions.Value.Get(entity).value,
                    rotation = _rotations.Value.Get(entity).value,
                    team = _teamTypes.Value.Get(entity)
                };
            }
        }
    }
}