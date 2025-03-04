// using Leopotam.EcsLite.Di;
//
// namespace SampleGame
// {
//     public readonly struct UnitStoppingDistanceUseCase
//     {
//         private readonly EcsPoolInject<Radius> _radii;
//         private readonly EcsPoolInject<StoppingDistance> _stoppingDistances;
//
//         public float CalculateStoppingDistance(int entity, int target)
//         {
//             if (!_stoppingDistances.Value.Has(entity) || !_radii.Value.Has(target) || !_radii.Value.Has(entity))
//                 return 0f;
//
//             float unitStoppingDistance = _stoppingDistances.Value.Get(entity).value;
//             float targetRadius = _radii.Value.Get(target).value;
//             float unitRadius = _radii.Value.Get(entity).value;
//
//             return unitStoppingDistance + targetRadius + unitRadius;
//         }
//     }
// }