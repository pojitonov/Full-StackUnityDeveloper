using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class LookAtComponent : MonoBehaviour
    {
        public Vector2 LookAtDirection { get; private set; } = Vector2.right;

        [SerializeField] private float _detectionRadius = 1f;
        [SerializeField] private LayerMask _mask;

        private MoveComponent _moveComponent;

        private void Awake()
        {
            _moveComponent = GetComponent<MoveComponent>();
        }

        private void Update()
        {
            UpdateLookAtDirection(_moveComponent.Direction);
        }

        public IEnumerable<GameObject> GetInteractables()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, _detectionRadius, _mask);

            foreach (var collider in colliders)
            {
                GameObject interactable = collider.gameObject;
                if (interactable && IsLookingAtObject(collider.transform.position))
                    yield return interactable;
            }
        }

        private void UpdateLookAtDirection(Vector2 direction)
        {
            if (direction == Vector2.right || direction == Vector2.left) 
                LookAtDirection = direction;
        }

        private bool IsLookingAtObject(Vector3 objectPosition)
        {
            Vector2 toObject = (objectPosition - transform.position).normalized;
            return Vector2.Dot(LookAtDirection, toObject) > 0;
        }
    }
}