using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class JumpComponent : MonoBehaviour
    {
        public event Action OnJumped;

        [SerializeField] private float _forceStrength = 8f;
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private readonly CompositeCondition _condition = new();

        public void Jump()
        {
            if (!_condition.IsTrue())
                return;

            _rigidbody.AddForce(new Vector2(0, _forceStrength), ForceMode2D.Impulse);
            OnJumped?.Invoke();
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}