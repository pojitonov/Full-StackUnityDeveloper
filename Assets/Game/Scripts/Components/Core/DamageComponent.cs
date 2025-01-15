using UnityEngine;

namespace Game.Scripts
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int _damageValue = 1;
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

            healthComponent.TakeDamage(_damageValue);
        }
    }
}