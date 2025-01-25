using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts
{
    public sealed class Spider : MonoBehaviour
    {
        [SerializeField] private DamageTriggerComponent _damageTriggerComponent;
        [SerializeField] private DamageApplierComponent _damageApplierComponent;
        [SerializeField] private DamagePushComponent _damagePushComponent;

        private void Awake()
        {
            _damageTriggerComponent.OnDamageTriggered += HandleDamage;
            _damageApplierComponent.OnDamaged += HandlePush;
        }

        private void OnDestroy()
        {
            _damageTriggerComponent.OnDamageTriggered -= HandleDamage;
            _damageApplierComponent.OnDamaged -= HandlePush;
        }

        private void HandleDamage(GameObject target)
        {
            _damageApplierComponent.TryApplyDamage(target);
        }
        
        private void HandlePush(GameObject target)
        {
            _damagePushComponent.ApplyPush(target);
        }
    }
}