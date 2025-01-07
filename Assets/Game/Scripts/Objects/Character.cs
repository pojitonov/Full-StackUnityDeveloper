using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public class Character : MonoBehaviour
    {
        public float _jumpForce = 8f;
        public bool _isAlive = true;

        [ShowInInspector, ReadOnly]
        public bool _isGrounded = true;

        [ShowInInspector, ReadOnly]
        public float _moveDirection;

        [SerializeField]
        private float _moveSpeed = 5f;

        [SerializeField]
        private float _groundDistance = 0.1f;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Transform _feetTransform;

        public JumpAction _jumpAction;
        
        private MovementMechanic _movementMechanic;
        private FlipMechanic _flipMechanic;
        private GroundMechanic _groundMechanic;

        private void Awake()
        {
            _movementMechanic = new MovementMechanic(_rigidbody, _moveSpeed);
            _flipMechanic = new FlipMechanic(transform);
            _jumpAction = new JumpAction(_rigidbody, _jumpForce);
            _groundMechanic = new GroundMechanic(_feetTransform, _isGrounded, _groundDistance);
            
            _jumpAction.AddCondition(() => _isGrounded && _isAlive);
            _movementMechanic.AddCondition(() => _isAlive);
        }

        private void FixedUpdate()
        {
            _movementMechanic.FixedUpdate(_moveDirection);
            _flipMechanic.FixedUpdate(_moveDirection);
            _groundMechanic.FixedUpdate();
            _isGrounded = _groundMechanic.CanJump;
        }

        private void OnDrawGizmos()
        {
            _groundMechanic?.OnDrawGizmos();
        }
    }
}