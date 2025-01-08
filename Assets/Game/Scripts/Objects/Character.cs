using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public sealed class Character : MonoBehaviour
    {
        public float MoveDirection { get; set; }

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private MoveComponent _moveComponent;

        [SerializeField]
        private JumpComponent _jumpComponent;


        public bool _isAlive = true;

        [ShowInInspector, ReadOnly]
        public bool _isGrounded = true;

        [SerializeField]
        private float _groundDistance = 0.1f;

        [SerializeField]
        private Transform _feetTransform;

        public JumpAction _jumpAction;

        private FlipMechanic _flipMechanic;
        private GroundMechanic _groundMechanic;

        private void Awake()
        {
            _moveComponent.Initialize(_rigidbody);
            
            _flipMechanic = new FlipMechanic(transform);
            
            _moveComponent.AddCondition(() => _isAlive);
            
            // _jumpAction = new JumpAction(_rigidbody, _jumpForce);
            // _jumpAction.AddCondition(() => _isGrounded && _isAlive);
            // _groundMechanic = new GroundMechanic(_feetTransform, _isGrounded, _groundDistance);
        }

        private void FixedUpdate()
        {
            _moveComponent.Move(MoveDirection);
            _flipMechanic.Flip(MoveDirection);
            
            // _groundMechanic.FixedUpdate();
            // _isGrounded = _groundMechanic.CanJump;
        }
    }
}