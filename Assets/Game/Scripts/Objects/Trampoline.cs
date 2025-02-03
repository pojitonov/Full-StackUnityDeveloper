using UnityEngine;

namespace Game
{
    public sealed class Trampoline : MonoBehaviour
    {
        [SerializeField] private ForceComponent _forceComponent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other) return;
            _forceComponent.ApplyForce(other.gameObject);
        }
    }
}