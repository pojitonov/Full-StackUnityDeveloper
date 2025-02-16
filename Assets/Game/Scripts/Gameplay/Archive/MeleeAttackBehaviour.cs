// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     public class MeleeAttackBehaviour : IEntityInit, IEntityDispose, IEntityGizmos
//     {
//         private IEvent _isAttacking;
//         private readonly Transform _center;
//         private readonly int _damage;
//         private readonly float _attackRadius;
//         private IEntity _entity;
//         private static readonly LayerMask LAYER_MASK = LayerMask.GetMask("Character");
//
//         public MeleeAttackBehaviour(float attackRadius, int damage, Transform center)
//         {
//             _attackRadius = attackRadius;
//             _damage = damage;
//             _center = center;
//         }
//
//         public void Init(in IEntity entity)
//         {
//             _entity = entity;
//             _isAttacking = entity.GetAttackEvent();
//             _isAttacking.Subscribe(OnAttack);
//         }
//
//         public void Dispose(in IEntity entity)
//         {
//             _isAttacking.Unsubscribe(OnAttack);
//         }
//
//         private void OnAttack()
//         {
//             MeleeAttackUseCase.Attack(_entity, _center.position, _attackRadius, _damage, LAYER_MASK);
//         }
//
//         public void OnGizmosDraw(in IEntity entity)
//         {
//             Gizmos.color = Color.red;
//             Gizmos.DrawWireSphere(_center.position, _attackRadius);
//         }
//     }
// }