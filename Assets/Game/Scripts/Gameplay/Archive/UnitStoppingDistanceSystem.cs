// using Leopotam.EcsLite;
// using Leopotam.EcsLite.Di;
//
// namespace SampleGame
// {
//     public sealed class UnitStoppingDistanceSystem : IEcsRunSystem
//     {
//         private readonly EcsWorldInject _world;
//         private readonly EcsFilterInject<Inc<AttackableTag>> _attackables;
//         private readonly EcsPoolInject<StoppingDistance> _stoppingDistances;
//         private readonly EcsPoolInject<Target> _targets;
//         private readonly EcsUseCaseInject<UnitStoppingDistanceUseCase> _useCase;
//
//         public void Run(IEcsSystems systems)
//         {
//             foreach (var unit in _attackables.Value)
//             {
//                 if (!_targets.Value.Has(unit)) continue;
//
//                 ref var targetData = ref _targets.Value.Get(unit);
//                 if (!targetData.target.Unpack(_world.Value, out int targetEntity))
//                     continue;
//
//                 ref var stoppingDistance = ref _stoppingDistances.Value.Get(unit);
//                 stoppingDistance.value = _useCase.Value.CalculateStoppingDistance(unit, targetEntity);
//             }
//         }
//     }
// }