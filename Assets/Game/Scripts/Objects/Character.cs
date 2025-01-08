using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public sealed class Character : MonoBehaviour, IKillable
    {
        [ShowInInspector, ReadOnly]
        private bool _isAlive = true;

        [ShowInInspector, ReadOnly]
        private bool _isGrounded = true;

        public MoveComponent _moveComponent;
        public JumpComponent _jumpComponent;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Transform _feetTransform;

        private FlipMechanic _flipMechanic;
        private IsGroundMechanic _isGroundMechanic;

        private void Awake()
        {
            _moveComponent.Initialize(_rigidbody);
            _moveComponent.AddCondition(() => _isAlive);

            _jumpComponent.Initialize(_rigidbody);
            _jumpComponent.AddCondition(() => _isGrounded && _isAlive);

            _flipMechanic = new FlipMechanic(transform);
            _isGroundMechanic = new IsGroundMechanic(_feetTransform);
        }

        private void FixedUpdate()
        {
            _flipMechanic.Flip(_moveComponent.GetDirection());
            _isGrounded = _isGroundMechanic.Check();
        }

        public void Kill()
        {
            _isAlive = false;
            gameObject.SetActive(false);
        }
    }
}