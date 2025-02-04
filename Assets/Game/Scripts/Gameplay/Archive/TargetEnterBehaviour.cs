// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     public class TargetEnterBehaviour : IEntityInit, IEntityDispose
//     {
//         private IAction _targetAction;
//
//         public void Init(in IEntity entity)
//         {
//             _targetAction = entity.GetTargetAction();
//             _targetAction.(OnTargetDetected);
//         }
//
//         public void Dispose(in IEntity entity)
//         {
//             _targetEvent.Unsubscribe(OnTargetDetected);
//         }
//
//         private void OnTargetDetected()
//         {
//             Debug.Log("Target Detected");
//         }
//     }
// }