// using Leopotam.EcsLite;
// using Leopotam.EcsLite.Di;
//
// namespace SampleGame
// {
//     public class StoppingDistanceSystem : IEcsRunSystem
//     {
//         private readonly EcsFilterInject<Inc<UnitTag, Target, StoppingDistance>> _units;
//         private readonly EcsFilterInject<Inc<BaseTag>> _bases;
//         private readonly EcsPoolInject<UnitTag> _unitTags;
//         private readonly EcsPoolInject<BaseTag> _baseTags;
//         private readonly EcsPoolInject<Target> _targets;
//         private readonly EcsPoolInject<StoppingDistance> _stoppingDistances;
//         private readonly EcsPoolInject<EcsName> _names;
//
//         private const float DefaultStoppingDistance = 5f; // Default distance for non-unit, non-base
//
//         public void Run(IEcsSystems systems)
//         {
//             var world = systems.GetWorld();
//
//             foreach (var entity in _units.Value)
//             {
//                 // Check if the entity itself is alive
//                 if (!world.IsAlive()) continue;
//
//                 var target = _targets.Value.Get(entity).value;
//                 if (target < 0 || !world.IsAlive()) continue;
//
//                 ref var stoppingDistanceComponent = ref _stoppingDistances.Value.Get(entity);
//                 stoppingDistanceComponent.value = GetStoppingDistance(target);
//             }
//         }
//
//         private float GetStoppingDistance(int target)
//         {
//             if (_baseTags.Value.Has(target))
//                 return DefaultStoppingDistance;
//
//             if (_unitTags.Value.Has(target))
//             {
//                 var targetName = _names.Value.Get(target).value;
//                 return targetName switch
//                 {
//                     "Swordman" => 2f,
//                     "Archer" => 10f,
//                     _ => DefaultStoppingDistance
//                 };
//             }
//
//             return DefaultStoppingDistance;
//         }
//     }
// }