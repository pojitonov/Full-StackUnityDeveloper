using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class MoveAnimBehaviour: IEntityInit, IEntityDispose
    {
        private readonly int _hash;
        private Animator _animator;
        private IReactiveValue<Vector3> _moveDirection;
        
        public MoveAnimBehaviour(string hash)
        {
            _hash = Animator.StringToHash(hash);
        }
        
        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _moveDirection = entity.GetMoveDirection();
            _moveDirection.Observe(OnMoveDirectionChanged);
        }

        public void Dispose(in IEntity entity)
        {
            _moveDirection.Unsubscribe(OnMoveDirectionChanged);
        }

        private void OnMoveDirectionChanged(Vector3 direction)
        {
            _animator.SetBool(_hash, direction != Vector3.zero);
        }
    }
}