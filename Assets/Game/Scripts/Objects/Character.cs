using Game.Scripts.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Objects
{
    public sealed class Character : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private LookAtComponent _lookAtComponent;
        [SerializeField] private StandingComponent _standingComponent;
        [SerializeField] private GroundComponent _groundComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private FlipComponent _flipComponent;
        [SerializeField] private JumpComponent _jumpComponent;
        [SerializeField] private ForceComponent _forceComponent;
        [SerializeField] private DamageTriggerComponent _damageTriggerComponent;
        [FormerlySerializedAs("_damageApplierComponent")]
        [SerializeField] private DamageApplyComponent _damageApplyComponent;
        [SerializeField] private DeathHandler _deathHandler;
        
        private void Awake()
        {
            _moveComponent.AddCondition(() => _healthComponent.IsAlive);
            _jumpComponent.AddCondition(() => _healthComponent.IsAlive && _groundComponent.IsGrounded);
            _forceComponent.AddCondition(() => _healthComponent.IsAlive, ForceType.Push);
            _forceComponent.AddCondition(() => _healthComponent.IsAlive && _groundComponent.IsGrounded,
                ForceType.Toss);

            _healthComponent.OnDied += _deathHandler.TriggerDeath;
            _damageTriggerComponent.OnDamageTriggered += target => _damageApplyComponent.TryApplyDamage(target);
        }

        private void OnDestroy()
        {
            _healthComponent.OnDied -= _deathHandler.TriggerDeath;
            _damageTriggerComponent.OnDamageTriggered -= target => _damageApplyComponent.TryApplyDamage(target);
        }

        private void Update()
        {
            _flipComponent.Direction = _moveComponent.Direction;
            _lookAtComponent.SetDirection(_moveComponent.Direction);
            _standingComponent.UpdateStanding(_groundComponent.IsGrounded, _groundComponent.Transform);
        }
    }
}