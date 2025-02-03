using UnityEngine;

namespace Game
{
    public sealed class Character : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private LookAtComponent _lookAtComponent;
        [SerializeField] private StandingComponent _standingComponent;
        [SerializeField] private GroundComponent _groundComponent;
        [SerializeField] private InteractableComponent _interactableComponent;
        [SerializeField] private ColliderEventsListener _colliderEventsListener;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private FlipComponent _flipComponent;
        [SerializeField] private JumpComponent _jumpComponent;
        [SerializeField] private PushComponent _pushComponent;
        [SerializeField] private TossComponent _tossComponent;
        [SerializeField] private DamageComponent _damageComponent;
        [SerializeField] private DeathComponent _deathComponent;

        private Vector3 LookDirection => _lookAtComponent.Direction;

        private void Awake()
        {
            _moveComponent.AddCondition(() => _healthComponent.IsAlive);
            _jumpComponent.AddCondition(() => _healthComponent.IsAlive && _groundComponent.IsGrounded);
            _pushComponent.AddCondition(() => _healthComponent.IsAlive);
            _tossComponent.AddCondition(() => _healthComponent.IsAlive && _groundComponent.IsGrounded);
            
            _healthComponent.OnDied += _deathComponent.TriggerDeath;
            _colliderEventsListener.OnEventTriggered += target => _damageComponent.TryApplyDamage(target);
        }

        private void OnDestroy()
        {
            _healthComponent.OnDied -= _deathComponent.TriggerDeath;
            _colliderEventsListener.OnEventTriggered -= _damageComponent.TryApplyDamage;
        }

        private void Update()
        {
            _flipComponent.Direction = _moveComponent.Direction;
            _lookAtComponent.SetDirection(_moveComponent.Direction);
        }

        public void Toss()
        {
            _tossComponent.Invoke(Vector3.up, LookDirection);
        }

        public void Push()
        {
            _pushComponent.Invoke(LookDirection, LookDirection);
        }

        public void Jump()
        {
            _jumpComponent.Invoke();
        }
        
        public void Move(Vector2 direction)
        {
            _moveComponent.Direction = direction;
        }
    }
}