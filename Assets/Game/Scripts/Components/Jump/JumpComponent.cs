using System;
using Game.Scripts.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Components
{
    public class JumpComponent : MonoBehaviour
    {
        public event Action OnJumped;

        [SerializeField] private float _forceStrength = 10f;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Cooldown cooldown;

        private readonly Condition _condition = new();

        private void Update()
        {
            cooldown.Tick(Time.deltaTime);
        }

        public void Jump()
        {
            if (!_condition.IsTrue() || !cooldown.IsTimeUp())
                return;
            cooldown.Reset();

            GamePhysics.AddForce(_rigidbody, Vector2.up, _forceStrength, ForceMode2D.Impulse);
            OnJumped?.Invoke();
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}