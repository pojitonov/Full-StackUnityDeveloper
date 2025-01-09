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

        private readonly CompositeCondition _condition = new();

        public void Move(Vector2 direction)
        {
            _direction = direction;

            if (!_condition.IsTrue())
                return;

            _transform.position += (Vector3)_direction.normalized * (_speed * Time.deltaTime);
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}