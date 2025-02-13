// using Leopotam.EcsLite;
// using Leopotam.EcsLite.Di;
//
// namespace SampleGame
// {
//     public sealed class PlayerFireController : IEcsRunSystem
//     {
//         private readonly EcsSharedInject<GameData> _gameData;
//         private readonly EcsFilterInject<Inc<CanFire>> _units;
//         private readonly EcsPoolInject<TeamType> _teamTypes;
//
//         public void Run(IEcsSystems systems)
//         {
//             foreach (var entity in _units.Value)
//             {
//                 var teamType = _teamTypes.Value.Get(entity);
//                 if (teamType == TeamType.RED)
//                     continue;
//                 
//                 ref CanFire fire = ref _units.Pools.Inc1.Get(entity);
//                 fire.value = _gameData.Value.inputData.isFire;
//             }
//         }
//     }
// }