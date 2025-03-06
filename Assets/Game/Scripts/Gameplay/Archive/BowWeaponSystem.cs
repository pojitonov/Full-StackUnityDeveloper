// using Leopotam.EcsLite;
// using Leopotam.EcsLite.Di;
// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class BowWeaponSystem : IEcsRunSystem
//     {
//         private readonly EcsWorldInject _world;
//         private readonly EcsPoolInject<Weapon> _meleeWeapons;
//
//         public void Run(IEcsSystems systems)
//         {
//             var filter = _world.Value.Filter<Weapon>().End();
//
//             foreach (int entity in filter)
//             {
//                 ref Weapon weapon = ref _meleeWeapons.Value.Get(entity);
//
//                 Debug.Log($"Attack with: {weapon}");
//             }
//         }
//     }
// }