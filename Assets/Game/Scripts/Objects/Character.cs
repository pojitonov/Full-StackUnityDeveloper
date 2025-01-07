using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public class Character : MonoBehaviour
    {
        public bool _jumpEnabled = true;
        public float _jumpForce = 8f;

        [SerializeField]
        private float _moveSpeed = 5f;
        
        [SerializeField]
        private float _groundDistance = 0.1f;

        [ShowInInspector, ReadOnly]
        public float _moveDirection;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Transform _feetTransform;

        public JumpAction _jumpAction;
        
        private MovementMechanic _movementMechanic;
        private FlipMechanic _flipMechanic;
        private FloorMechanic _floorMechanic;

        private void Awake()
        {
            _movementMechanic = new MovementMechanic(_rigidbody, _moveSpeed);
            _flipMechanic = new FlipMechanic(transform);
            _jumpAction = new JumpAction(_rigidbody, _jumpForce);
            _floorMechanic = new FloorMechanic(_feetTransform, _jumpEnabled, _groundDistance);
        }

        private void FixedUpdate()
        {
            _movementMechanic.FixedUpdate(_moveDirection);
            _flipMechanic.FixedUpdate(_moveDirection);
            _floorMechanic.FixedUpdate();
            _jumpEnabled = _floorMechanic.CanJump;
        }
    }
}