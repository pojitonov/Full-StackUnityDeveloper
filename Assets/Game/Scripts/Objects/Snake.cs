using UnityEngine;

namespace Game
{
    public sealed class Snake : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private PatrolComponent _patrolComponent;
        [SerializeField] private FlipComponent _flipComponent;
        [SerializeField] private ColliderEventsListener _colliderEventsListener;
        [SerializeField] private TriggerEventsListener _triggerEventsListener;
        [SerializeField] private DamageComponent _damageComponent;
        [SerializeField] private ForceComponent _forceComponent;
        [SerializeField] private DeathComponent _deathComponent;

        private void Awake()
        {
            _healthComponent.OnDied += _deathComponent.TriggerDeath;
            _colliderEventsListener.OnEventTriggered += target => _damageComponent.TryApplyDamage(target);
            _triggerEventsListener.OnEventTriggered += target => _damageComponent.TryApplyDamage(target);
            _damageComponent.OnDamagedApplied += target => _forceComponent.ApplyForce(target);
            
            _patrolComponent.SetMoveable(_moveComponent);
        }

        private void OnDestroy()
        {
            _healthComponent.OnDied -= _deathComponent.TriggerDeath;
            _colliderEventsListener.OnEventTriggered -= _damageComponent.TryApplyDamage;
            _triggerEventsListener.OnEventTriggered -= _damageComponent.TryApplyDamage;
            _damageComponent.OnDamagedApplied -= _forceComponent.ApplyForce;
        }

        private void Update()
        {
            _flipComponent.Direction = _moveComponent.Direction;
        }
        
    }
}