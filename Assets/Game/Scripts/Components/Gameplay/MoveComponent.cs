using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Scripts
{
    public class MoveComponent : MonoBehaviour
    {
        public Transform Transform => _transform;
        public Vector2 Direction => _direction;
        
        [ShowInInspector, ReadOnly]
        private Vector2 _direction;
        
        [SerializeField]
        private float _speed = 5f;
        
        [SerializeField]
        private Transform _transform;

        private readonly CompositeCondition _condition = new();

        public void Move(Vector2 direction)
        {
            _direction = direction.normalized;

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