using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public sealed class Snake : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private PatrolComponent _patrolComponent;
        [SerializeField] private FlipComponent _flipComponent;
        [SerializeField] private DamageTriggerComponent _damageTriggerComponent;
        [SerializeField] private DamageComponent _damageComponent;
        [SerializeField] private DamagePushComponent _damagePushComponent;
        [SerializeField] private DeathHandlerComponent _deathHandlerComponent;

        private void Awake()
        {
            _patrolComponent.Init(_moveComponent);
            
            _healthComponent.OnDied += _deathHandlerComponent.TriggerDeath;
            _damageTriggerComponent.OnDamageTriggered += target => _damageComponent.TryApplyDamage(target);
            _damageComponent.OnDamagedApplied += target => _damagePushComponent.ApplyPush(target);
        }

        private void OnDestroy()
        {
            _healthComponent.OnDied -= _deathHandlerComponent.TriggerDeath;
            _damageTriggerComponent.OnDamageTriggered -= _damageComponent.TryApplyDamage;
            _damageComponent.OnDamagedApplied -= _damagePushComponent.ApplyPush;
        }

        private void Update()
        {
            _flipComponent.Direction = _moveComponent.Direction;
        }
        
    }
}