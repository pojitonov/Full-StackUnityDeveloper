using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    // TODO: Распилить на более мелкие компоненты и возможно что то упразднить
    public class LookAtComponent : MonoBehaviour
    {
        public Vector2 LookAtDirection => _lookAtDirection;

        [SerializeField] private float _detectionRadius = 1f;
        [SerializeField] private LayerMask _mask;

        private Vector2 _lookAtDirection = Vector2.right;
        private MoveComponent _moveComponent;

        private void Awake()
        {
            _moveComponent = GetComponent<MoveComponent>();
        }

        private void Update()
        {
            UpdateFacingDirection(_moveComponent.Direction);
        }

        private void UpdateFacingDirection(Vector2 direction)
        {
            if (direction == Vector2.right || direction == Vector2.left)
            {
                _lookAtDirection = direction;
            }
        }

        public IEnumerable<IInteractable> GetInteractableInFront()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _detectionRadius, _mask);

            foreach (var collider in colliders)
            {
                IInteractable interactable = FindInteractableInHierarchy(collider);

                if (interactable != null && IsLookingAtObject(collider.transform.position))
                {
                    yield return interactable;
                }
            }
        }

        private IInteractable FindInteractableInHierarchy(Collider2D collider)
        {
            return collider.GetComponent<IInteractable>()
                   ?? collider.GetComponentInParent<IInteractable>()
                   ?? collider.GetComponentInChildren<IInteractable>();
        }

        private bool IsLookingAtObject(Vector3 objectPosition)
        {
            Vector2 toObject = (objectPosition - transform.position).normalized;
            return Vector2.Dot(_lookAtDirection, toObject) > 0;
        }
    }
}