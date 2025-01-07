using UnityEngine;

namespace Game.Scripts
{
    public class OnGroundMechanic
    {
        private static readonly int GROUND_MASK = LayerMask.GetMask("Ground");

        public bool CanJump => _canJump;

        private readonly Transform _groundPoint;
        private readonly float _distance;
        private bool _canJump;
        
        public OnGroundMechanic(Transform groundPoint, bool canJump, float distance)
        {
            _groundPoint = groundPoint;
            _canJump = canJump;
            _distance = distance;
        }

        public void FixedUpdate()
        {
            _canJump = Physics2D.Raycast(_groundPoint.position, Vector2.down, _distance, GROUND_MASK);
        }

        public void OnDrawGizmos()
        {
            Gizmos.DrawLine(_groundPoint.position, _groundPoint.position + Vector3.down * _distance);
        }
    }
}