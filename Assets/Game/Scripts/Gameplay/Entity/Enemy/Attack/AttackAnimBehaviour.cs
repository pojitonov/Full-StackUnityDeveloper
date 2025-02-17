using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class AttackAnimBehaviour : IEntityInit, IEntityDispose
    {
        private readonly int _hash;
        private Animator _animator;
        private IEvent _attackEvent;

        public AttackAnimBehaviour(string hash)
        {
            _hash = Animator.StringToHash(hash);
        }

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _attackEvent = entity.GetWeapon().GetAttackEvent();
            _attackEvent.Subscribe(OnAttack);
        }

        public void Dispose(in IEntity entity)
        {
            _attackEvent.Unsubscribe(OnAttack);
        }

        private void OnAttack()
        {
            _animator.SetTrigger(_hash);
        }
    }
}