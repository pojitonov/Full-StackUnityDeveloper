using System;
using UnityEngine;

namespace Game
{
    public class DamageComponent : MonoBehaviour
    {
        public event Action<GameObject> OnDamagedApplied;

        [SerializeField] private int _damagePoints = 1;
        [SerializeField] private Cooldown cooldown;

        private void Update()
        {
            cooldown.Tick(Time.deltaTime);
        }
        
        public void TryApplyDamage(GameObject other)
        {
            if (!cooldown.IsTimeUp())
                return;
            
            var health = other.GetComponentInParent<HealthComponent>();
            if (health == null)
                return;
            
            health.TakeDamage(_damagePoints);
            cooldown.Reset();
            
            OnDamagedApplied?.Invoke(other);
        }
    }
}