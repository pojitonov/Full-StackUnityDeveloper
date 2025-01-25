using System;
using Game.Scripts.Core;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class DamageApplierComponent : MonoBehaviour
    {
        public event Action<GameObject> OnDamaged;

        [SerializeField] private int _damagePoints = 1;
        [SerializeField] private Cooldown cooldown;

        private void Update()
        {
            cooldown.Tick(Time.deltaTime);
        }
        
        public void TryApplyDamage(GameObject other)
        {
            var health = other.GetComponentInParent<HealthComponent>();
            if (health == null)
                return;
            health.TakeDamage(_damagePoints);
            cooldown.Reset();
            OnDamaged?.Invoke(other);
        }
    }
}