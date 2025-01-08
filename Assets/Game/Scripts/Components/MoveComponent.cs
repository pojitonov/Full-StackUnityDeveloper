using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    [Serializable]
    public class MoveComponent
    {
        [SerializeField]
        private float _speed = 5f;

        [ShowInInspector, ReadOnly]
        private float _direction;

        private Rigidbody2D _rigidbody;
        private readonly CompositeCondition _condition = new();

        public void Initialize(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public float GetDirection()
        {
            return _direction;
        }
        
        public void Move(float direction)
        {
            _direction = direction;

            if (!_condition.IsTrue())
                return;

            float speedY = _rigidbody.velocity.y;
            float speedX = _direction * _speed;
            _rigidbody.velocity = new Vector2(speedX, speedY);
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}