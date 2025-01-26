using Game.Scripts.Components;
using UnityEngine;

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
        [SerializeField] private DeathHandlerComponent _deathHandlerComponent;
        
        private void Awake()
        {
            _patrolComponent.Init(_moveComponent);
            
            _healthComponent.OnDied += _deathHandlerComponent.TriggerDeath;
            _damageTriggerComponent.OnDamageTriggered += target => _damageApplyComponent.TryApplyDamage(target);
            _damageTriggerComponent.OnDamageTriggered += target => _damagePushComponent.ApplyPush(target);
        }

        private void OnDestroy()
        {
            _healthComponent.OnDied -= _deathHandlerComponent.TriggerDeath;
            _damageTriggerComponent.OnDamageTriggered -= target => _damageApplyComponent.TryApplyDamage(target);
            _damageTriggerComponent.OnDamageTriggered -= target => _damagePushComponent.ApplyPush(target);
        }
    }
}