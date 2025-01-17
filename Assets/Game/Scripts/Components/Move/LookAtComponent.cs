using UnityEngine;

namespace Game.Scripts.Components
{
    public class LookAtComponent : MonoBehaviour
    {
        public Vector2 Direction { get; private set; } = Vector2.right;
        public float DetectionRadius => _detectionRadius;
        public LayerMask LayerLayerMask => _layerMask;

        [SerializeField] private float _detectionRadius = 1f;
        [SerializeField] private LayerMask _layerMask;

        public void SetDirection(Vector2 direction)
        {
            if (direction == Vector2.right || direction == Vector2.left) 
                Direction = direction;
        }
    }
}