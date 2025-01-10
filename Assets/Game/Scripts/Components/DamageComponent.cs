using System;
using UnityEngine;

namespace Game.Scripts
{
    public class DamageComponent : MonoBehaviour, ITriggerable
    {
        public event Action OnStateChanged;

        [SerializeField]
        private int _damageValue = 1;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            ApplyDamage(other.gameObject);
        }
        
        private void ApplyDamage(GameObject other)
        {
            HealthComponent damageable = other.GetComponent<HealthComponent>();

            if (damageable != null)
            {
                damageable.TakeDamage(_damageValue);
                OnStateChanged?.Invoke();
            }
        }
    }
}