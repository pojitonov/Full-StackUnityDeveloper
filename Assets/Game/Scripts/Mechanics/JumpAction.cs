using System;
using UnityEngine;

namespace Game.Scripts
{
    public class JumpAction
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _force;
        private readonly CompositeCondition _condition = new();

        public JumpAction(Rigidbody2D rigidbody, float force)
        {
            _rigidbody = rigidbody;
            _force = force;
        }

        public void Invoke()
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