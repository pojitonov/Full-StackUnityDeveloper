using System;
using UnityEngine;

namespace Game.Scripts
{
    internal class MovementMechanic
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _moveSpeed;
        private readonly CompositeCondition _condition = new();

        public MovementMechanic(Rigidbody2D rigidbody, float moveSpeed)
        {
            _rigidbody = rigidbody;
            _moveSpeed = moveSpeed;
        }

        public void FixedUpdate(float moveDirection)
        {
            if (!_condition.IsTrue())
                return;
            
            float speedY = _rigidbody.velocity.y;
            float speedX = moveDirection * _moveSpeed;
            _rigidbody.velocity = new Vector2(speedX, speedY);
        }
        
        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}