using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public sealed class Character : MonoBehaviour
    {
        public MoveComponent _moveComponent;
        public JumpComponent _jumpComponent;
        
        [SerializeField]
        private Rigidbody2D _rigidbody;
        
        [ShowInInspector, ReadOnly]
        private bool _isAlive = true;
        [ShowInInspector, ReadOnly]
        private bool _isGrounded = true;

        [SerializeField]
        private float _groundDistance = 0.1f;

        [SerializeField]
        private Transform _feetTransform;
        
        private FlipMechanic _flipMechanic;
        private GroundMechanic _groundMechanic;

        private void Awake()
        {
            _moveComponent.Initialize(_rigidbody);
            _jumpComponent.Initialize(_rigidbody);
            
            _flipMechanic = new FlipMechanic(transform);
            // _groundMechanic = new GroundMechanic(_feetTransform, _isGrounded, _groundDistance);
            
            _moveComponent.AddCondition(() => _isAlive);
            _jumpComponent.AddCondition(() => _isGrounded && _isAlive);
        }

        private void FixedUpdate()
        {
            _flipMechanic.Flip(_moveComponent.GetDirection());
            
            // _groundMechanic.FixedUpdate();
            // _isGrounded = _groundMechanic.CanJump;
        }
    }
}