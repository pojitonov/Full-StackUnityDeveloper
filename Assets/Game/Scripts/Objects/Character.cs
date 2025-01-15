using UnityEngine;

namespace Game.Scripts
{
    public sealed class Character : MonoBehaviour
    {
        public Vector2 MoveDirection { get; set; }

        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private JumpComponent _jumpComponent;
        [SerializeField] private PushComponent _pushComponent;
        [SerializeField] private TossComponent _tossComponent;
        [SerializeField] private GroundComponent _groundComponent;
        [SerializeField] private LookAtComponent _lookAtComponent;
        [SerializeField] private HealthComponent _healthComponent;

        private void Awake()
        {
            _moveComponent.AddCondition(() => _healthComponent.IsAlive);
            _jumpComponent.AddCondition(() => _groundComponent.IsGrounded && _healthComponent.IsAlive);
        }

        private void FixedUpdate()
        {
            _moveComponent.Move(MoveDirection);
        }
    }
}