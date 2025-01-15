using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    // TODO: Змея при дамаге толкает вверх
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int _damagePoints = 1;
        [SerializeField] private bool _colliderIsTrigger;
        [SerializeField] private Countdown _delay;

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

            healthComponent.TakeDamage(_damagePoints);
        }
    }
}