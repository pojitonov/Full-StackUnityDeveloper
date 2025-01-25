using Game.Scripts.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts
{
    public sealed class Spider : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private PatrolComponent _patrolComponent;
        [SerializeField] private DamageTriggerComponent _damageTriggerComponent;
        [SerializeField] private DamageApplyComponent _damageApplyComponent;
        [SerializeField] private DamagePushComponent _damagePushComponent;
        [SerializeField] private DeathHandler _deathHandler;
        
        private void Awake()
        {
            _patrolComponent.Init(_moveComponent);
            
            _healthComponent.OnDied += _deathHandler.TriggerDeath;
            _damageTriggerComponent.OnDamageTriggered += target => _damageApplyComponent.TryApplyDamage(target);
            _damageTriggerComponent.OnDamageTriggered += target => _damagePushComponent.ApplyPush(target);
        }

        private void OnDestroy()
        {
            _healthComponent.OnDied -= _deathHandler.TriggerDeath;
            _damageTriggerComponent.OnDamageTriggered -= target => _damageApplyComponent.TryApplyDamage(target);
            _damageTriggerComponent.OnDamageTriggered -= target => _damagePushComponent.ApplyPush(target);
        }
    }
}