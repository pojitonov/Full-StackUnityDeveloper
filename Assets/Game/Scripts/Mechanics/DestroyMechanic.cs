using UnityEngine;

namespace Game.Scripts
{
    // TODO: Перепилить в компоненты
    
    public class DestroyMechanic
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<HealthComponent>(out var component))
            {
                component.Destroy();
            }
        }
    }
}