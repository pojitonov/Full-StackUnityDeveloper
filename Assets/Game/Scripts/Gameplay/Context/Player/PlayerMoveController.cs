using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public class PlayerMoveController : IEcsRunSystem
    {
        private readonly EcsSharedInject<GameData> _gameData;
        private readonly EcsFilterInject<Inc<UnitDirection>> _movables;
        private readonly EcsPoolInject<TeamType> _teamTypes;

        public void Run(IEcsSystems systems)
        {
            ref float3 moveDirection = ref _gameData.Value.inputData.moveDirection;

            foreach (var entity in _movables.Value)
            {
                var teamType = _teamTypes.Value.Get(entity);
                if (teamType == TeamType.RED)
                    continue;
                
                _movables.Pools.Inc1.Get(entity).value = moveDirection;
            }
        }
    }
}