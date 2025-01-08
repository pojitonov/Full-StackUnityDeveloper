using UnityEngine;

namespace Game.Scripts
{
    public class DestroyMechanic
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<IDestroyable>(out var component))
            {
                component.Destroy();
            }
        }
    }
}