// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     public sealed class MoveTowardsBehaviour : IEntityFixedUpdate
//     {
//         public void OnFixedUpdate(in IEntity entity, in float deltaTime)
//         {
//             IReactiveVariable<Vector3> direction = entity.GetMoveDirection();
//             entity.MoveTowards(direction.Value, deltaTime);
//         }
//     }
// }