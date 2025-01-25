using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class MoveAnimBehaviour: IEntityInit, IEntityDispose
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private Animator _animator;
        private IReactiveValue<Vector3> _moveDirection;
        
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
            _animator.SetBool(IsMoving, direction != Vector3.zero);
        }
    }
}