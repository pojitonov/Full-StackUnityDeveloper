using System;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class DestroyerComponent : MonoBehaviour
    {
        public event Action OnDestroyed;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }

        private void Destroy(GameObject other)
        {
            var component = other.GetComponentInParent<HealthComponent>();
            if (component == null)
                return;

            component.Destroy();
            OnDestroyed?.Invoke();
        }
    }
}