using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public class HandAttackBehaviour : IEntityInit, IEntityDispose, IEntityGizmos
    {
        private IEvent _isAttacking;
        private readonly Transform _center;
        private readonly int _damage;
        private readonly float _attackRadius;
        private static readonly LayerMask LAYER_MASK = LayerMask.GetMask("Character");

        public HandAttackBehaviour(float attackRadius, int damage, Transform center)
        {
            _attackRadius = attackRadius;
            _damage = damage;
            _center = center;
        }

        public void Init(in IEntity entity)
        {
            _isAttacking = entity.GetAttackingEvent();
            _isAttacking.Subscribe(OnAttack);
        }

        public void Dispose(in IEntity entity)
        {
            _isAttacking.Unsubscribe(OnAttack);
        }

        private void OnAttack()
        {
            HandAttackUseCase.Attack(_center.position, _attackRadius, _damage, LAYER_MASK);
        }

        public void OnGizmosDraw(in IEntity entity)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_center.position, _attackRadius);
        }
    }
}