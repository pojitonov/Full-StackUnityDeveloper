// using Atomic.Entities;
// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     public static class EnemyAttackUseCase
//     {
//         public static void Attack(in IEntity entity, in float stoppingDistance)
//         {
//             if (entity == null) 
//                 return;
//             
//             if (!entity.HasTarget())
//                 return;
//
//             var target = entity.GetTarget();
//
//             var distance = entity.GetDistance(target);
//             if (distance < stoppingDistance)
//                 entity.GetAttackEvent().Invoke();
//         }
//     }
// }