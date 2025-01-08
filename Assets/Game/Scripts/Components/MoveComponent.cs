using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    [Serializable]
    public class MoveComponent
    {
        [SerializeField]
        private float _moveSpeed = 5f;

        [ShowInInspector, ReadOnly]
        private float _moveDirection;

        private Rigidbody2D _rigidbody;
        private readonly CompositeCondition _condition = new();

        public void Initialize(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Move(float moveDirection)
        {
            _moveDirection = moveDirection;

            if (!_condition.IsTrue())
                return;

            float speedY = _rigidbody.velocity.y;
            float speedX = _moveDirection * _moveSpeed;
            _rigidbody.velocity = new Vector2(speedX, speedY);
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}