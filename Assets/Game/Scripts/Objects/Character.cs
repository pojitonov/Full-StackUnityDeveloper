using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public class Character : MonoBehaviour
    {
        public bool _jumpEnabled = true;
        public JumpAction _jumpAction;
        public float _jumpForce;

        [ShowInInspector, ReadOnly]
        public float _moveDirection;

        [SerializeField]
        private float _moveSpeed;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        private MovementMechanics _movementMechanics;
        private FlipMechanics _flipMechanics;

        private void Awake()
        {
            _movementMechanics = new MovementMechanics(_rigidbody, _moveSpeed);
            _flipMechanics = new FlipMechanics(transform);
            _jumpAction = new JumpAction(_rigidbody, _jumpForce, _jumpEnabled);
        }

        private void FixedUpdate()
        {
            _movementMechanics.FixedUpdate(_moveDirection);
            _flipMechanics.FixedUpdate(_moveDirection);
        }
    }
}