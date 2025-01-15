using System;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class DestroyerComponent : MonoBehaviour
    {
        public event Action OnDestroyed;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<HealthComponent>(out var component))
                return;
            
            component.Destroy();
            OnDestroyed?.Invoke();
        }
    }
}