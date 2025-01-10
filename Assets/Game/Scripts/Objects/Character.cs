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
        
        private bool _isGrounded = true;

        private void Awake()
        {
            _moveComponent.AddCondition(() => _healthComponent.IsAlive);
            _jumpComponent.AddCondition(() => _isGrounded && _healthComponent.IsAlive);
            
            _groundComponent.OnStateChanged += value => _isGrounded = value;
        }

        private void OnDestroy()
        {
            _groundComponent.OnStateChanged -= value => _isGrounded = value;
        }

        private void FixedUpdate()
        {
            _moveComponent.Move(MoveDirection);
        }
    }
}