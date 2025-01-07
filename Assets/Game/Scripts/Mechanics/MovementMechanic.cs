using UnityEngine;

namespace Game.Scripts
{
    internal class MovementMechanic
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _moveSpeed;

        public MovementMechanic(Rigidbody2D rigidbody, float moveSpeed)
        {
            _rigidbody = rigidbody;
            _moveSpeed = moveSpeed;
        }

        public void FixedUpdate(float moveDirection)
        {
            float speedY = _rigidbody.velocity.y;
            float speedX = moveDirection * _moveSpeed;
            _rigidbody.velocity = new Vector2(speedX, speedY);
        }
    }
}