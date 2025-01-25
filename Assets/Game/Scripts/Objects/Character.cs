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
        [SerializeField] private GroundComponent _groundComponent;
        [SerializeField] private LookAtComponent _lookAtComponent;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private DamageTriggerComponent _damageTriggerComponent;
        [SerializeField] private DamageApplierComponent _damageApplierComponent;

        private void Awake()
        {
            _moveComponent.AddCondition(() => _healthComponent.IsAlive);
            _forceActionComponent.AddCondition(() => _healthComponent.IsAlive);
            // _tossComponent.AddCondition(() => _healthComponent.IsAlive && _groundComponent.IsGrounded);
            _jumpComponent.AddCondition(() => _healthComponent.IsAlive && _groundComponent.IsGrounded);

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
        }

        private void HandleDamage(GameObject target)
        {
            _damageApplierComponent.TryApplyDamage(target);
        }
    }
}