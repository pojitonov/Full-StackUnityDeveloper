using System;
using UnityEngine;

namespace Game.Scripts
{
    public class DamageComponent : MonoBehaviour, ITriggerable
    {
        public event Action OnStateChanged;

        [SerializeField] private int _damageValue = 1;
        [SerializeField] private bool _colliderIsTrigger;
        [SerializeField] private Countdown _delay;
        [SerializeField] private float _pushBackForce = 5f;
        
        private void Update()
        {
            _delay.Tick(Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_colliderIsTrigger && _delay.IsTimeUp())
            {
                ApplyDamage(other.gameObject);
                _delay.Reset();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!_colliderIsTrigger)
            {
                ApplyDamage(other.gameObject);
            }
        }

        private void ApplyDamage(GameObject other)
        {
            if (!other.TryGetComponent<HealthComponent>(out var healthComponent)) 
                return;
            
            healthComponent.TakeDamage(_damageValue);
            PushBack(other);
            OnStateChanged?.Invoke();
        }

        private void PushBack(GameObject other)
        {
            if (!other.TryGetComponent<Rigidbody2D>(out var rbComponent)) 
                return;
            
            Vector2 pushDirection = other.transform.position - transform.position;
            var pushMechanic = new PushMechanic(rbComponent);
            pushMechanic.Invoke(pushDirection, _pushBackForce);
        }
    }
}