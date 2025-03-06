// using Leopotam.EcsLite;
// using Leopotam.EcsLite.Di;
// using UnityEngine;
//
// namespace SampleGame
// {
//     [CreateAssetMenu(fileName = "Melee", menuName = "SampleGame/Entities/New Melee")]
//     public sealed class MeleePrototype : EcsPrototype
//     {
//         private readonly EcsUseCaseInject<FireUseCase> _fireUseCase;
//
//         protected override void Install(in EcsWorld world, in int entity)
//         {
//             world.GetPool<WeaponTag>().Add(entity);
//         }
//     }
// }