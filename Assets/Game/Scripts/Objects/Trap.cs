using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts
{
    public sealed class Trap : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private StandingComponent _standingComponent;
        [SerializeField] private GroundComponent _groundComponent;
        [SerializeField] private DamageTriggerComponent _damageTriggerComponent;
        [SerializeField] private DamageApplyComponent _damageApplyComponent;
        [SerializeField] private DeathHandlerComponent _deathHandlerComponent;
        
        private void Awake()
        {
            _damageTriggerComponent.OnDamageTriggered += target => _damageApplyComponent.TryApplyDamage(target);
            _healthComponent.OnDied += _deathHandlerComponent.TriggerDeath;
        }

        private void OnDestroy()
        {
            _damageTriggerComponent.OnDamageTriggered -= target => _damageApplyComponent.TryApplyDamage(target);
            _healthComponent.OnDied -= _deathHandlerComponent.TriggerDeath;
        }
        
        private void Update()
        {
            _standingComponent.UpdateStanding(_groundComponent.IsGrounded, _groundComponent.Transform);
        }
    }
}