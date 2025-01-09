using UnityEngine;

namespace Game.Scripts
{
    public class PushComponent : MonoBehaviour
    {
        [SerializeField]
        private float _forceStrength = 5f;

        [SerializeField]
        private float _detectionRadius = 1f;

        [SerializeField]
        private LayerMask _mask;
        
        public void Push(Vector2 lookAtDirection, Vector2 pushDirection)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _detectionRadius, _mask);

            foreach (var collider in colliders)
            {
                IInteractable interactable = collider.GetComponent<IInteractable>()
                                             ?? collider.GetComponentInParent<IInteractable>()
                                             ?? collider.GetComponentInChildren<IInteractable>();
                if (interactable != null)
                {
                    Vector2 toObject = (collider.transform.position - transform.position).normalized;

                    if (Vector2.Dot(lookAtDirection, toObject) > 0)
                    {
                        interactable.Push(pushDirection, _forceStrength);
                    }
                }
            }
        }
    }
}