using UnityEngine;

namespace Game
{
    public sealed class Trap : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private ColliderEventsListener _colliderEventsListener;
        [SerializeField] private DamageComponent _damageComponent;
        [SerializeField] private DeathComponent _deathComponent;
        
        private void Awake()
        {
            _colliderEventsListener.OnEventTriggered += _damageComponent.TryApplyDamage;
            _healthComponent.OnDied += _deathComponent.TriggerDeath;
        }

        private void OnDestroy()
        {
            _colliderEventsListener.OnEventTriggered -= _damageComponent.TryApplyDamage;
            _healthComponent.OnDied -= _deathComponent.TriggerDeath;
        }
    }
}