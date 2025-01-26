using UnityEngine;

namespace Game.Scripts.Components
{
    public class GroundComponent : MonoBehaviour
    {
        public bool IsGrounded { get; private set; }
        public Transform Transform { get; private set; }

        [SerializeField] private float _detectDistance = 0.1f;
        [SerializeField] private Transform _feetTransform;
        [SerializeField] private LayerMask _layerMask;

        private void Update()
        {
            Transform = GetRaycastTransform(_feetTransform, Vector2.down, _detectDistance, _layerMask);
            IsGrounded = Transform is not null;
        }

        private Transform GetRaycastTransform(Transform transform, Vector2 direction, float distance,
            LayerMask layerMask)
        {
            var raycast = Physics2D.Raycast(transform.position, direction, distance, layerMask);
            return raycast.transform;
        }
    }
}