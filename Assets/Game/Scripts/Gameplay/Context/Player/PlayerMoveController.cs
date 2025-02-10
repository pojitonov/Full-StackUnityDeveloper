using Game.Context;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace Game
{
    public class PlayerMoveController : IEcsRunSystem
    {
        private readonly EcsSharedInject<GameData> _gameData;
        private readonly EcsFilterInject<Inc<UnitDirection>> _movables;

        public void Run(IEcsSystems systems)
        {
            ref float3 moveDirection = ref _gameData.Value.inputData.moveDirection;

            foreach (var entity in _movables.Value)
            {
                _movables.Pools.Inc1.Get(entity).value = moveDirection;
            }
        }
    }
}