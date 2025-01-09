using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class LookAtComponent : MonoBehaviour
    {
        public Vector2 LookAtDirection => _lookAtDirection;
        
        [SerializeField]
        private float _detectionRadius = 1f;

        [SerializeField]
        private LayerMask _mask;
        
        private Vector2 _lookAtDirection = Vector2.right;
        private Character _character;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        public void Update()
        {
            UpdateFacingDirection(_character.MoveDirection);
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
                IInteractable interactable = GetInteractableInHierarchy(collider);

                if (interactable != null && IsLookingAtObject(collider.transform.position))
                {
                    yield return interactable;
                }
            }
        }

        private IInteractable GetInteractableInHierarchy(Collider2D collider)
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