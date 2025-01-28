using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class DeathAnimBehaviour : IEntityInit, IEntityDispose
    {
        private readonly int _hash;
        private Animator _animator;
        private IReactive _deathEvent;
        
        public DeathAnimBehaviour(string hash)
        {
            _hash = Animator.StringToHash(hash);
        }
        
        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _deathEvent = entity.GetDeathEvent();
            _deathEvent.Subscribe(OnDeathHappen);
        }

        public void Dispose(in IEntity entity)
        {
            _deathEvent.Unsubscribe(OnDeathHappen);
        }

        private void OnDeathHappen()
        {
            _animator.SetTrigger(_hash);
        }
    }
}