using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class JumpComponent : MonoBehaviour
    {
        public event Action OnJumped;

        [SerializeField] private float _forceStrength = 10f;
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private readonly Condition _condition = new();
        private GamePhysics _physics;

        public void Jump()
        {
            if (!_condition.IsTrue())
                return;

            GamePhysics.AddForce(_rigidbody, Vector2.up, _forceStrength, ForceMode2D.Impulse);
            OnJumped?.Invoke();
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}