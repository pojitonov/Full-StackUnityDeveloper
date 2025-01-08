using UnityEngine;

namespace Game.Scripts
{
    [RequireComponent(typeof(MoveComponent), typeof(JumpComponent))]
    public sealed class Character : MonoBehaviour, IDestroyable
    {
        public Vector2 MoveDirection { get; set; }
        public MoveComponent _moveComponent;
        public JumpComponent _jumpComponent;

        [SerializeField]
        private Transform _feetTransform;

        private FlipMechanic _flipMechanic;
        private GroundMechanic _groundMechanic;
        
        private bool _isAlive = true;
        private bool _isGrounded = true;
        
        private void Awake()
        {
            _moveComponent.AddCondition(() => _isAlive);
            _jumpComponent.AddCondition(() => _isGrounded && _isAlive);

            _flipMechanic = new FlipMechanic(transform);
            _groundMechanic = new GroundMechanic(_feetTransform);
        }

        private void FixedUpdate()
        {
            _moveComponent.Move(MoveDirection);
            _flipMechanic.Invoke(MoveDirection);
            _isGrounded = _groundMechanic.Invoke();
        }

        public void Destroy()
        {
            _isAlive = false;
            gameObject.SetActive(false);
        }
    }
}