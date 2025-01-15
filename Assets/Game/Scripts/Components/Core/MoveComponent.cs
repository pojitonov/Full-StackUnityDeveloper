using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public class MoveComponent : MonoBehaviour
    {
        public Vector2 MoveDirection { get; set; }
        public Transform Transform => _transform;

        [ShowInInspector, ReadOnly] private Vector2 _direction;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Transform _transform;

        private readonly CompositeCondition _condition = new();

        public void FixedUpdate()
        {
            _direction = MoveDirection.normalized;

            if (!_condition.IsTrue())
                return;

            _transform.position += (Vector3)_direction * (_speed * Time.deltaTime);
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}