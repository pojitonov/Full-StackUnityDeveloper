using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public class MoveComponent : MonoBehaviour, IMoveable
    {
        [field: ShowInInspector, ReadOnly] public Vector2 Direction { get; set; }
        public Vector3 Position => _transform.position;

        [SerializeField] private float _speed = 5f;
        [SerializeField] private Transform _transform;

        private readonly Condition _condition = new();

        public void FixedUpdate()
        {
            if (!_condition.IsTrue())
                return;

            _transform.position += (Vector3)Direction.normalized * (_speed * Time.deltaTime);
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}