using System;
using UnityEngine;

namespace Game.Scripts
{
    public class JumpComponent : MonoBehaviour, ITriggerable
    {
        public event Action OnStateChanged;

        [SerializeField]
        private float _force = 8f;

        [SerializeField]
        private Rigidbody2D _rigidbody;
        
        private readonly CompositeCondition _condition = new();

        public void Jump()
        {
            if (!_condition.IsTrue())
                return;

            _rigidbody.AddForce(new Vector2(0, _force), ForceMode2D.Impulse);
            OnStateChanged?.Invoke();
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}