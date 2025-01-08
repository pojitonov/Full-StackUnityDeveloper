using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public class MoveComponent : MonoBehaviour
    {
        public Transform _transform;
        
        [SerializeField]
        private float _speed = 5f;

        [ShowInInspector, ReadOnly]
        private Vector2 _direction;

        private Rigidbody2D _rigidbody;
        private readonly CompositeCondition _condition = new();

        public void Initialize(Rigidbody2D rigidbody, Transform transform)
        {
            _rigidbody = rigidbody;
            _transform = transform;
        }

        public Vector2 GetDirection()
        {
            return _direction;
        }

        public void Move(Vector2 direction)
        {
            _direction = direction;

            if (!_condition.IsTrue())
                return;

            _transform.position += (Vector3)_direction.normalized * _speed * Time.deltaTime;

            // float speedY = _rigidbody.velocity.y;
            // float speedX = _direction.x * _speed;
            // _rigidbody.velocity = new Vector2(speedX, speedY);
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}