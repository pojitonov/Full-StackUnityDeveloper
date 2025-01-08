using UnityEngine;

namespace Game.Scripts
{
    public class IsGroundMechanic
    {
        private const float _groundDistance = 0.1f;
        private static readonly int GROUND_MASK = LayerMask.GetMask("Ground");
        private readonly Transform _groundPoint;
        private readonly float _distance;

        public IsGroundMechanic(Transform groundPoint)
        {
            _groundPoint = groundPoint;
        }

        public bool Check()
        {
            return Physics2D.Raycast(_groundPoint.position, Vector2.down, _groundDistance, GROUND_MASK);
        }
    }
}