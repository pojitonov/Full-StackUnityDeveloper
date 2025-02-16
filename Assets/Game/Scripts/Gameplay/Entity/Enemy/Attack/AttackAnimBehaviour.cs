using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class AttackAnimBehaviour : IEntityInit, IEntityDispose
    {
        private readonly int _hash;
        private Animator _animator;
        private IEvent _isAttacking;

        public AttackAnimBehaviour(string hash)
        {
            _hash = Animator.StringToHash(hash);
        }

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _isAttacking = entity.GetAttackEvent();
            _isAttacking.Subscribe(OnAttack);
        }

        public void Dispose(in IEntity entity)
        {
            _isAttacking.Unsubscribe(OnAttack);
        }

        private void OnAttack()
        {
            _animator.SetTrigger(_hash);
        }
    }
}