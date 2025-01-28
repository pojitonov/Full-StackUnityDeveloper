using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class FireAnimBehaviour: IEntityInit, IEntityDispose
    {
        private readonly int _hash;
        private Animator _animator;
        private IReactive _fireEvent;
        
        public FireAnimBehaviour(string hash)
        {
            _hash = Animator.StringToHash(hash);
        }

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _fireEvent = entity.GetFireEvent();
            _fireEvent.Subscribe(OnFire);
        }

        public void Dispose(in IEntity entity)
        {
            _fireEvent.Unsubscribe(OnFire);
        }

        private void OnFire()
        {
            _animator.SetTrigger(_hash);
        }
    }
}