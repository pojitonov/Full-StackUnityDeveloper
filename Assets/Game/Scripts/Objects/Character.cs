using UnityEngine;

namespace Game.Scripts
{
    public sealed class Character : MonoBehaviour, IDestroyable
    {
        public Vector2 MoveDirection { get; set; }
        
        public MoveComponent _moveComponent;
        public JumpComponent _jumpComponent;
        public PushComponent _pushComponent;
        public GroundComponent _groundComponent;
        public LookAtComponent _lookAtComponent;
        public HealthComponent _healthComponent;
        
        private bool _isAlive = true;
        private bool _isGrounded = true;

        private void Awake()
        {
            _moveComponent.AddCondition(() => _isAlive);
            _jumpComponent.AddCondition(() => _isGrounded && _isAlive);
            
            _groundComponent.OnStateChanged += value => _isGrounded = value;
            _healthComponent.OnDie += value => _isAlive = value;
        }

        private void OnDestroy()
        {
            _groundComponent.OnStateChanged -= value => _isGrounded = value;
            _healthComponent.OnDie -= value => _isAlive = value;
        }

        private void FixedUpdate()
        {
            _moveComponent.Move(MoveDirection);
        }

        public void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}