using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts
{
    public sealed class Trap : MonoBehaviour
    {
        [SerializeField] private DamageTriggerComponent _damageTriggerComponent;
        [SerializeField] private DamageApplierComponent _damageApplierComponent;

        private void Awake()
        {
            _damageTriggerComponent.OnDamageTriggered += HandleDamage;
        }

        private void OnDestroy()
        {
            _damageTriggerComponent.OnDamageTriggered -= HandleDamage;
        }

        private void HandleDamage(GameObject target)
        {
            _damageApplierComponent.TryApplyDamage(target);
        }
    }
}