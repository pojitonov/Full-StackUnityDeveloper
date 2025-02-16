// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     public class MeleeAttackAction : IAction
//     {
//         // private IEvent _isAttacking;
//         private readonly IEntity _entity;
//         private readonly float _stoppingDistance;
//         private readonly int _damage;
//         private readonly Transform _center;
//         private readonly LayerMask _layerMask;
//
//         public MeleeAttackAction(IWeaponEntity entity, float stoppingDistance, int damage, Transform center, LayerMask layerMask)
//         {
//             _entity = entity;
//             _stoppingDistance = stoppingDistance;
//             _damage = damage;
//             _center = center;
//             _layerMask = layerMask;
//         }
//
//         public void Invoke()
//         {
//             MeleeAttackUseCase.Attack(_entity, _center.position, _stoppingDistance, _damage, _layerMask);
//         }
//     }
// }