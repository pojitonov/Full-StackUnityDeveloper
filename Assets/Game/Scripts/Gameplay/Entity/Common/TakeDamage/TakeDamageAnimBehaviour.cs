using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class TakeDamageAnimBehaviour : IEntityInit, IEntityDispose
    {
        private readonly int _hash;
        private Animator _animator;
        private IReactive<DamageArgs> _damageEvent;
        
        public TakeDamageAnimBehaviour(string hash)
        {
            _hash = Animator.StringToHash(hash);
        }
        
        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _damageEvent = entity.GetTakeDamageEvent();
            _damageEvent.Subscribe(OnDamageTaken);
        }

        public void Dispose(in IEntity entity)
        {
            _damageEvent.Unsubscribe(OnDamageTaken);
        }

        private void OnDamageTaken(DamageArgs _)
        {
            _animator.SetTrigger(_hash);
        }
    }
}