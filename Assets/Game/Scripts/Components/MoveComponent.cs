using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Scripts
{
    public class MoveComponent : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private Vector2 _direction;
        
        [SerializeField]
        private float _speed = 5f;
        
        [SerializeField]
        private Transform _transform;

        private readonly CompositeCondition _condition = new();

        public void Move(Vector2 direction)
        {
            _direction = direction;

            if (!_condition.IsTrue())
                return;

            _transform.position += (Vector3)_direction.normalized * (_speed * Time.deltaTime);
        }

        public Vector3 GetTransform()
        {
            return _transform.position;
        }
        
        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}