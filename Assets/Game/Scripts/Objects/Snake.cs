using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public sealed class Snake : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private FlipComponent _flipComponent;
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

        private void Update()
        {
            _flipComponent.Direction = _moveComponent.Direction;
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