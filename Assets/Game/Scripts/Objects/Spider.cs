// using UnityEngine;
//
// namespace Game.Scripts
// {
//     public sealed class Spider : MonoBehaviour, IDestroyable
//     {
//         public MoveComponent _moveComponent;
//         public PatrolComponent _patrolComponent;
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
//         private bool _isAlive = true;
//
//         private void Awake()
//         {
//             _moveComponent.Initialize(_rigidbody, _transform);
//             _moveComponent.AddCondition(() => _isAlive);
//         }
//
//         private void Update()
//         {
//             _moveComponent.Move(MoveDirection);
//         }
//
//         public void Destroy()
//         {
//             _isAlive = false;
//             gameObject.SetActive(false);
//         }
//     }
// }