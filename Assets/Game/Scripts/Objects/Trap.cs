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
        [FormerlySerializedAs("_damageApplierComponent")]
        [SerializeField] private DamageApplyComponent _damageApplyComponent;
        [SerializeField] private DeathHandler _deathHandler;
        
        private void Awake()
        {
            _damageTriggerComponent.OnDamageTriggered += target => _damageApplyComponent.TryApplyDamage(target);
            _healthComponent.OnDied += _deathHandler.TriggerDeath;
        }

        private void OnDestroy()
        {
            _damageTriggerComponent.OnDamageTriggered -= target => _damageApplyComponent.TryApplyDamage(target);
            _healthComponent.OnDied -= _deathHandler.TriggerDeath;
        }
        
        private void Update()
        {
            _standingComponent.UpdateStanding(_groundComponent.IsGrounded, _groundComponent.Transform);
        }
    }
}