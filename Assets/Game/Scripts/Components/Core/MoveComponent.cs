using System;
using Game.Scripts.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class MoveComponent : MonoBehaviour
    {
        public Vector2 Direction
        {
            get => _moveDirection;
            set => _moveDirection = value;
        }
        public Transform Transform => _transform;

        [ShowInInspector, ReadOnly] private Vector2 _moveDirection;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Transform _transform;

        private readonly CompositeCondition _condition = new();

        public void FixedUpdate()
        {
            if (!_condition.IsTrue())
                return;

            _transform.position += (Vector3)_moveDirection.normalized * (_speed * Time.deltaTime);
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}