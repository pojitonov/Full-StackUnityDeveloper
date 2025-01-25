using System;
using Game.Scripts.Core;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class ForceActionComponent : MonoBehaviour
    {
        public event Action OnPush;
        public event Action OnToss;

        [SerializeField] private float _forceStrength;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _detectionRadius = 1f;
        [SerializeField] private Cooldown cooldown;
        
        private readonly Condition _condition = new();

        private void Update()
        {
            cooldown.Tick(Time.deltaTime);
        }

        public void ApplyForce(Vector2 forceDirection, Vector2 lookAtDirection)
        {
            if (!_condition.IsTrue() || !cooldown.IsTimeUp())
                return;
            cooldown.Reset();

            var item = GamePhysics.GetInteractable(
                transform.position,
                _detectionRadius,
                _layerMask,
                lookAtDirection);

            GamePhysics.AddForceToInteractable(item, forceDirection, _forceStrength);
        }
        
        public void InvokePush()
        {
            OnPush?.Invoke();
        }

        public void InvokeToss()
        {
            OnToss?.Invoke();
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}