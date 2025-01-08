// using UnityEngine;
//
// namespace Game.Scripts
// {
//     public sealed class Platform : MonoBehaviour
//     {
//         public MoveComponent _moveComponent;
//         
//         [SerializeField]
//         private Rigidbody2D _rigidbody;
//
//         [SerializeField]
//         private Transform _transform;
//         
//         [SerializeField]
//         private Transform[] _waypoints;
//         
//         private PatrolMechanic _patrolMechanic;
//
//         private void Awake()
//         {
//             _moveComponent.Initialize(_rigidbody, _transform);
//             _patrolMechanic = new PatrolMechanic(_waypoints);
//         }
//
//         private void FixedUpdate()
//         {
//             _moveComponent.Move(_patrolMechanic.Invoke(_transform));
//         }
//     }
// }