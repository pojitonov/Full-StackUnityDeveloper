using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts
{
    public class Character : MonoBehaviour
    {
        public float _jumpForce = 8f;

        [SerializeField]
        private float _moveSpeed = 5f;

        [SerializeField]
        private float _groundDistance = 0.1f;

        [ShowInInspector, ReadOnly]
        public bool _isJumpEnabled = true;
        
        public bool _isAlive = true;

        [ShowInInspector, ReadOnly]
        public float _moveDirection;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Transform _feetTransform;

        public JumpAction _jumpAction;
        
        private MovementMechanic _movementMechanic;
        private FlipMechanic _flipMechanic;
        private OnGroundMechanic _onGroundMechanic;

        private void Awake()
        {
            _movementMechanic = new MovementMechanic(_rigidbody, _moveSpeed);
            _flipMechanic = new FlipMechanic(transform);
            _jumpAction = new JumpAction(_rigidbody, _jumpForce);
            _onGroundMechanic = new OnGroundMechanic(_feetTransform, _isJumpEnabled, _groundDistance);
            
            _jumpAction.AddCondition(() => _isJumpEnabled && _isAlive);
            _movementMechanic.AddCondition(() => _isAlive);
        }

        private void FixedUpdate()
        {
            _movementMechanic.FixedUpdate(_moveDirection);
            _flipMechanic.FixedUpdate(_moveDirection);
            _onGroundMechanic.FixedUpdate();
            _isJumpEnabled = _onGroundMechanic.CanJump;
        }

        private void OnDrawGizmos()
        {
            _onGroundMechanic?.OnDrawGizmos();
        }
    }
}