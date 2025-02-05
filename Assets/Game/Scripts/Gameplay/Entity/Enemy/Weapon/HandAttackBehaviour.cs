using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

// TODO Fix the MULTIPLIER thing
namespace Game.Gameplay
{
    public class HandAttackBehaviour : IEntityInit, IEntityDispose
    {
        private IEvent _isAttacking;
        private Vector3 _position;
        private readonly int _damage;
        private readonly float _attackRange;
        private static readonly LayerMask LAYER_MASK = LayerMask.GetMask("Character");
        private const float MULTIPLIER = 10;

        public HandAttackBehaviour(float attackRange, int damage)
        {
            _attackRange = attackRange;
            _damage = damage;
        }

        public void Init(in IEntity entity)
        {
            _position = entity.GetTransform().position;
            _isAttacking = entity.GetAttackingEvent();
            _isAttacking.Subscribe(OnAttack);
        }

        public void Dispose(in IEntity entity)
        {
            _isAttacking.Unsubscribe(OnAttack);
        }

        private void OnAttack()
        {
            HandAttackUseCase.Attack(_position, _damage, _attackRange * MULTIPLIER, LAYER_MASK);
        }
    }
}