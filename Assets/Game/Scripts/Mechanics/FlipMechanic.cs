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

        public void Invoke(float direction)
        {
            if (direction == 1)
            {
                _transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (direction == -1)
            {
                _transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}