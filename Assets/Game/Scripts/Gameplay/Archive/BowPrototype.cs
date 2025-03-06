// using Leopotam.EcsLite;
// using Leopotam.EcsLite.Di;
// using UnityEngine;
//
// namespace SampleGame
// {
//     [CreateAssetMenu(fileName = "Bow", menuName = "SampleGame/Entities/New Bow")]
//     public sealed class BowPrototype : EcsPrototype
//     {
//         [SerializeField] private ProjectilePrototype _arrow;
//         private readonly EcsUseCaseInject<FireUseCase> _fireUseCase;
//
//         protected override void Install(in EcsWorld world, in int entity)
//         {
//             world.GetPool<WeaponTag>().Add(entity);
//             world.GetPool<Projectile>().Add(entity).value = _arrow;
//         }
//     }
// }