using Game.Scripts.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts
{
    public sealed class Trap : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private StandingComponent _standingComponent;
        [SerializeField] private GroundComponent _groundComponent;
        [SerializeField] private DamageTriggerComponent _damageTriggerComponent;
        [SerializeField] private DamageComponent _damageComponent;
        [SerializeField] private DeathHandlerComponent _deathHandlerComponent;
        
        private void Awake()
        {
            _damageTriggerComponent.OnDamageTriggered += target => _damageComponent.TryApplyDamage(target);
            _healthComponent.OnDied += _deathHandlerComponent.TriggerDeath;
        }

        private void OnDestroy()
        {
            _damageTriggerComponent.OnDamageTriggered -= _damageComponent.TryApplyDamage;
            _healthComponent.OnDied -= _deathHandlerComponent.TriggerDeath;
        }
        
        private void Update()
        {
            _standingComponent.UpdateStanding(_groundComponent.IsGrounded, _groundComponent.Transform);
        }
    }
}