using System;
using Game.Scripts.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Components
{
    public class JumpComponent : MonoBehaviour
    {
        public event Action OnJumped;

        [SerializeField] private float _forceStrength = 10f;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Countdown _countdown;

        private readonly Condition _condition = new();
        private GamePhysics _physics;

        private void Update()
        {
            _countdown.Tick(Time.deltaTime);
        }

        public void Jump()
        {
            if (!_condition.IsTrue() || !_countdown.IsTimeUp())
                return;

            GamePhysics.AddForce(_rigidbody, Vector2.up, _forceStrength, ForceMode2D.Impulse);
            _countdown.Reset();
            OnJumped?.Invoke();
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}