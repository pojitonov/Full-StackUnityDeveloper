// using Game;
// using UnityEngine;
//
// namespace Game
// {
//     public class DamagePushComponent : MonoBehaviour
//     {
//         [SerializeField] private PushType _pushType;
//         [SerializeField] private ForceComponent _forceComponent;
//
//         private Vector2 forceDirection;
//
//         public void Push(GameObject target)
//         {
//             if (_pushType == PushType.Horizontal)
//                 forceDirection = -(transform.position - target.transform.position);
//             else if (_pushType == PushType.Vertical)
//                 forceDirection = Vector2.up;
//
//             if (!target) return;
//             _forceComponent.ApplyForce(target, forceDirection);
//         }
//     }
//
//     public enum PushType
//     {
//         Horizontal,
//         Vertical
//     }
// }