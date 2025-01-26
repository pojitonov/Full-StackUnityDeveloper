using System;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class DestroyerComponent : MonoBehaviour
    {
        public event Action OnDestroyed;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var health = other.gameObject.GetComponentInParent<HealthComponent>();
            if (health == null) return;

            health.IsAlive = false;
            other.gameObject.SetActive(false);
            OnDestroyed?.Invoke();
        }
    }
}