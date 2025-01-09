using UnityEngine;

namespace Game.Scripts
{
    public class FlipMechanic
    {
        private readonly Transform _transform;

        public FlipMechanic(Transform transform)
        {
            _transform = transform;
        }

        public void Flip(Vector2 direction)
        {
            if (direction == Vector2.right)
            {
                _transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (direction == Vector2.left)
            {
                _transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}