using UnityEngine;

namespace Game.Scripts
{
    public class PushMechanic
    {
        private const float _multiplier = 100;
        private readonly Rigidbody2D _rigidbody;

        public PushMechanic(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Invoke(Vector2 direction, float force)
        {
            _rigidbody.AddForce(direction.normalized * force * _multiplier);
        }
    }
}