using UnityEngine;

namespace Game
{
    public sealed class Lava : MonoBehaviour
    {
        [SerializeField] private DestroyerComponent _destroyerComponent;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _destroyerComponent.TriggerDestroy(other.gameObject);
        }
    }
}