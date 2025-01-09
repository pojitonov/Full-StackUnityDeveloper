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
        
        private FlipMechanic _flipMechanic;
        
        private bool _isAlive = true;
        private bool _isGrounded = true;
        
        private void Awake()
        {
            _moveComponent.AddCondition(() => _isAlive);
            _jumpComponent.AddCondition(() => _isGrounded && _isAlive);
            _flipMechanic = new FlipMechanic(transform);
        }

        private void FixedUpdate()
        {
            _moveComponent.Move(MoveDirection);
            _flipMechanic.Flip(MoveDirection);
            _isGrounded = _groundComponent.CheckGround();
        }

        public void Destroy()
        {
            _isAlive = false;
            gameObject.SetActive(false);
        }
    }
}