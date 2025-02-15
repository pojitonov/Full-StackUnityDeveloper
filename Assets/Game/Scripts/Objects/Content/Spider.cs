using UnityEngine;

namespace Game
{
    public sealed class Spider : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private ColliderEventsListener _colliderEventsListener;
        [SerializeField] private TriggerEventsListener _triggerEventsListener;
        [SerializeField] private DamageComponent _damageComponent;
        [SerializeField] private ForceComponent _forceComponent;
        [SerializeField] private DeathComponent _deathComponent;

        private void Awake()
        {
            _healthComponent.OnDied += _deathComponent.TriggerDeath;
            _colliderEventsListener.OnEventTriggered += _damageComponent.TryApplyDamage;
            _triggerEventsListener.OnEventTriggered += _damageComponent.TryApplyDamage;
            _damageComponent.OnDamagedApplied += ApplyForceOnDamage;
        }

        private void OnDestroy()
        {
            _healthComponent.OnDied -= _deathComponent.TriggerDeath;
            _colliderEventsListener.OnEventTriggered -= _damageComponent.TryApplyDamage;
            _triggerEventsListener.OnEventTriggered -= _damageComponent.TryApplyDamage;
            _damageComponent.OnDamagedApplied -= ApplyForceOnDamage;
        }
        
        private void ApplyForceOnDamage(GameObject target)
        {
            var forceDirection = -(transform.position - target.transform.position);
            _forceComponent.ApplyForce(target, forceDirection);
        }
    }
}