using UnityEngine;

namespace Game.Scripts.Components
{
    public class InteractableDetectorComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _detectionRadius = 1f;

        public GameObject GetInteractable(Vector2 position, Vector2 lookDirection)
        {
            var collider = Physics2D.OverlapCircle(position, _detectionRadius, _layerMask);
            if (!collider) return null;

            var interactable = collider.gameObject;
            Vector2 toObject = (collider.transform.position - (Vector3)position).normalized;

            return Vector2.Dot(lookDirection, toObject) > 0 ? interactable : null;
        }
    }
}