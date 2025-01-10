using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts
{
    public class DamageComponent : MonoBehaviour, ITriggerable
    {
        public event Action OnStateChanged;

        [SerializeField]
        private int _damageValue = 1;

        [SerializeField]
        private bool _isTrigger;
        
        [SerializeField]
        private Countdown _delay;

        private void Update()
        {
            _delay.Tick(Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isTrigger && _delay.IsTimeUp())
            {
                ApplyDamage(other.gameObject);
                _delay.Reset();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!_isTrigger)
            {
                ApplyDamage(other.gameObject);
            }
        }

        private void ApplyDamage(GameObject other)
        {
            if (other.TryGetComponent<HealthComponent>(out var component))
            {
                component.TakeDamage(_damageValue);
                OnStateChanged?.Invoke();
            }
        }
    }
}