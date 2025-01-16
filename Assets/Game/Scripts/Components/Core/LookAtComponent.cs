using UnityEngine;

namespace Game.Scripts.Components
{
    public class LookAtComponent : MonoBehaviour
    {
        public Vector2 Direction { get; private set; } = Vector2.right;

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
        
        public float GetDetectionRadius() => _detectionRadius;
        public LayerMask GetLayerMask() => _mask;

        private void UpdateLookAtDirection(Vector2 direction)
        {
            if (direction == Vector2.right || direction == Vector2.left) 
                Direction = direction;
        }

        private bool IsLookingAtObject(Vector3 objectPosition)
        {
            Vector2 toObject = (objectPosition - transform.position).normalized;
            return Vector2.Dot(Direction, toObject) > 0;
        }
    }
}