using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private float _moveSpeed;

        [SerializeField]
        [ShowInInspector, ReadOnly]
        public float _moveDirection;

        private MovementMechanics _movementMechanics;
        private FlipMechanics _flipMechanics;

        private void Awake()
        {
            _movementMechanics = new MovementMechanics(_rigidbody, _moveSpeed);
            _flipMechanics = new FlipMechanics(transform);
        }

        private void FixedUpdate()
        {
            _movementMechanics.FixedUpdate(_moveDirection);
            _flipMechanics.FixedUpdate(_moveDirection);
        }
    }
}