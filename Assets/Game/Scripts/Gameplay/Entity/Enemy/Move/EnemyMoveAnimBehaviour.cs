// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     public class EnemyMoveAnimBehaviour: IEntityInit, IEntityDispose
//     {
//         private readonly int _hash;
//         private Animator _animator;
//         private IEntity _entity;
//         private IReactiveValue<Vector3> _moveDirection;
//         
//         public EnemyMoveAnimBehaviour(string hash)
//         {
//             _hash = Animator.StringToHash(hash);
//         }
//         
//         public void Init(in IEntity entity)
//         {
//             _entity = entity;
//             _animator = entity.GetAnimator();
//             _moveDirection = entity.GetMoveDirection();
//             _moveDirection.Observe(OnMoveDirectionChanged);
//         }
//
//         public void Dispose(in IEntity entity)
//         {
//             _moveDirection.Unsubscribe(OnMoveDirectionChanged);
//         }
//
//         private void OnMoveDirectionChanged(Vector3 direction)
//         {
//             bool hasTarget = _entity.HasTarget();
//             bool isMoving = direction != Vector3.zero;
//
//             _animator.SetBool(_hash, hasTarget && isMoving);
//         }
//     }
// }