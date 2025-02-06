// using Atomic.Elements;
// using Atomic.Entities;
// using Modules.Gameplay;
// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     public class HandInstaller : SceneEntityInstaller<IWeaponEntity>
//     {
//         [SerializeField] private Transform _transform;
//         [SerializeField] private float _attackRange = 1f;
//         [SerializeField] private int _damage = 10;
//         
//         protected override void Install(IWeaponEntity entity)
//         {
//             //Data:
//             entity.AddTransform(_transform);
//             
//             //Behaviours:
//             entity.AddBehaviour(new HandAttackBehaviour(_attackRange, _damage));
//         }
//     }
// }