using UnityEngine;

namespace Game.Scripts
{
    public class GroundComponent : MonoBehaviour
    {
        public bool IsGrounded { get; private set; }
        public Transform RaycastTransform { get; private set;}

        [SerializeField]
        private float _detectDistance = 0.1f;

        [SerializeField]
        private Transform _feetTransform;

        [SerializeField]
        private LayerMask _mask;

        private void Update()
        {
            var newState = CheckGround();
            if (newState == IsGrounded) return;
            IsGrounded = newState;
        }

        public bool CheckGround()
        {
            var raycast =  Physics2D.Raycast(_feetTransform.position, Vector2.down, _detectDistance, _mask);
            RaycastTransform = raycast.transform;
            return raycast;
        }
    }
}