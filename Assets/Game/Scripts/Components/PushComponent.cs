using UnityEngine;

namespace Game.Scripts
{
    public class PushComponent : MonoBehaviour
    {
        [SerializeField]
        private float _forceStrength = 500f;

        [SerializeField]
        private float _detectionRadius = 1f;

        [SerializeField]
        private LayerMask _mask;

        private IInteractable _nearbyInteractable;

        public void Push(Vector2 direction)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _detectionRadius, _mask);

            foreach (var collider in colliders)
            {
                IInteractable interactable = collider.GetComponent<IInteractable>()
                                             ?? collider.GetComponentInParent<IInteractable>()
                                             ?? collider.GetComponentInChildren<IInteractable>();
                if (interactable != null)
                {
                    interactable.Push(direction, _forceStrength);
                }
            }
        }
    }
}