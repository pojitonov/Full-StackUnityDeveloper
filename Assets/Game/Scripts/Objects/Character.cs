using UnityEngine;

namespace Game.Scripts
{
    public sealed class Character : MonoBehaviour
    {
        public Vector2 MoveDirection { get; set; }
        
        public MoveComponent _moveComponent;
        public JumpComponent _jumpComponent;
        public PushComponent _pushComponent;
        public TossComponent _tossComponent;
        public GroundComponent _groundComponent;
        public LookAtComponent _lookAtComponent;
        public HealthComponent _healthComponent;
        
        private void Awake()
        {
            _moveComponent.AddCondition(() => _healthComponent.IsAlive);
            _jumpComponent.AddCondition(() => _groundComponent.IsGrounded && _healthComponent.IsAlive);
        }

        private void FixedUpdate()
        {
            _moveComponent.Move(MoveDirection);
        }
    }
}