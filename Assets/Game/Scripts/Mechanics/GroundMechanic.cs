using UnityEngine;

namespace Game.Scripts
{
    public class GroundMechanic
    {
        private const float DISTANCE = 0.1f;
        private readonly int MASK = LayerMask.GetMask("Ground");
        private readonly Transform _transform;

        public GroundMechanic(Transform transform)
        {
            _transform = transform;
        }

        public bool Invoke()
        {
            return Physics2D.Raycast(_transform.position, Vector2.down, DISTANCE, MASK);
        }
    }
}