using System;
using UnityEngine;

namespace Game
{
    public class DestroyerComponent : MonoBehaviour
    {
        public event Action OnDestroyed;
        
        public void TriggerDestroy(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out HealthComponent healthComponent))
                healthComponent.IsAlive = false;
            
            gameObject.SetActive(false);
            
            OnDestroyed?.Invoke();
        }
    }
}