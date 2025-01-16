using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int _damagePoints = 1;
        [SerializeField] private bool _colliderIsTrigger;
        [SerializeField] private Countdown _countdown;

        private void Update()
        {
            _countdown.Tick(Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_colliderIsTrigger || !_countdown.IsTimeUp())
                return;
            ApplyDamage(other.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_colliderIsTrigger || !_countdown.IsTimeUp())
                return;
            ApplyDamage(other.gameObject);
        }

        private void ApplyDamage(GameObject other)
        {
            var health = other.GetComponentInParent<HealthComponent>();
            if (health == null)
                return;
            health.TakeDamage(_damagePoints);
            _countdown.Reset();
        }
    }
}