using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Components
{
    public class GroundComponent : MonoBehaviour
    {
        public bool IsGrounded { get; private set; }
        public Transform RaycastTransform { get; private set;}

        [SerializeField] private float _detectDistance = 0.1f;
        [SerializeField] private Transform _feetTransform;
        [SerializeField] private LayerMask _layerMask;

        private void Update()
        {
            var newState = CheckGround();
            if (newState == IsGrounded) return;
            IsGrounded = newState;
        }

        public bool CheckGround()
        {
            var raycast =  Physics2D.Raycast(_feetTransform.position, Vector2.down, _detectDistance, _layerMask);
            RaycastTransform = raycast.transform;
            return raycast;
        }
    }
}