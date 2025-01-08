using System;
using UnityEngine;

namespace Game.Scripts
{
    [Serializable]
    public class JumpComponent
    {
        [SerializeField]
        private float _force = 8f;

        private Rigidbody2D _rigidbody;
        private readonly CompositeCondition _condition = new();

        public void Initialize(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Jump()
        {
            if (!_condition.IsTrue())
                return;

            _rigidbody.AddForce(new Vector2(0, _force), ForceMode2D.Impulse);
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}