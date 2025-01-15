using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class GroundComponent : MonoBehaviour
    {
        public bool IsGrounded { get; private set; }
        public Transform GroundTransform { get; private set; }

        [SerializeField] private float _detectDistance = 0.1f;
        [SerializeField] private Transform _feetTransform;
        [SerializeField] private LayerMask _layerMask;
        
        private GamePhysics _physics;

        private void Update()
        {
            GroundTransform = GamePhysics.GetRaycastTransform(_feetTransform, Vector2.down, _detectDistance, _layerMask);
            if (GroundTransform == IsGrounded) 
                return;
            
            IsGrounded = GroundTransform;
        }
    }
}