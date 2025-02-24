// using Leopotam.EcsLite;
// using Leopotam.EcsLite.Di;
// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class AttackCooldownSystem : IEcsRunSystem
//     {
//         private readonly EcsFilterInject<Inc<AttackCooldown>> _cooldowns;
//
//         public void Run(IEcsSystems systems)
//         {
//             foreach (int entity in _cooldowns.Value)
//             {
//                 float deltaTime = Time.deltaTime;
//                 ref AttackCooldown cooldown = ref _cooldowns.Pools.Inc1.Get(entity);
//                 if (cooldown.current > 0)
//                     cooldown.current -= deltaTime;
//             }
//         }
//     }
// }