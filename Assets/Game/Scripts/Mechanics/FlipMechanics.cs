using UnityEngine;

namespace Game.Scripts
{
    public class FlipMechanics
    {
        private readonly Transform _transform;

        public FlipMechanics(Transform transform)
        {
            _transform = transform;
        }

        public void FixedUpdate(float moveDirection)
        {
            if (moveDirection == 1)
                _transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (moveDirection == -1)
                _transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}