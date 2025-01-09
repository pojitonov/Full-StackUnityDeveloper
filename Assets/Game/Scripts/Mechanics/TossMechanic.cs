using UnityEngine;

namespace Game.Scripts
{
    public class TossMechanic
    {
        private readonly Rigidbody2D _rigidbody;

        public TossMechanic(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Invoke(Vector2 direction, float force)
        {
            _rigidbody.AddForce(direction * force);
        }
    }
}