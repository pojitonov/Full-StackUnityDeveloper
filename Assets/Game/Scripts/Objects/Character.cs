using Game.Scripts.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Objects
{
    public sealed class Character : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private FlipComponent _flipComponent;
        [SerializeField] private JumpComponent _jumpComponent;
        [SerializeField] private ForceActionComponent _forceActionComponent;
        [SerializeField] private LookAtComponent _lookAtComponent;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private DamageTriggerComponent _damageTriggerComponent;
        [SerializeField] private DamageApplierComponent _damageApplierComponent;
        [SerializeField] private GroundComponent _groundComponent;
        [SerializeField] private StandingComponent _standingComponent;
        

        private void Awake()
        {
            _moveComponent.AddCondition(() => _healthComponent.IsAlive);
            _jumpComponent.AddCondition(() => _healthComponent.IsAlive && _groundComponent.IsGrounded);
            _forceActionComponent.AddCondition(() => _healthComponent.IsAlive, ForceType.Push);
            _forceActionComponent.AddCondition(() => _healthComponent.IsAlive && _groundComponent.IsGrounded, ForceType.Toss);

            _damageTriggerComponent.OnDamageTriggered += HandleDamage;
        }

        private void OnDestroy()
        {
            _damageTriggerComponent.OnDamageTriggered -= HandleDamage;
        }

        private void Update()
        {
            _flipComponent.Direction = _moveComponent.Direction;
            _lookAtComponent.SetDirection(_moveComponent.Direction);
            _standingComponent.UpdateStanding(_groundComponent.IsGrounded, _groundComponent.Transform);

        }

        private void HandleDamage(GameObject target)
        {
            _damageApplierComponent.TryApplyDamage(target);
        }
    }
}