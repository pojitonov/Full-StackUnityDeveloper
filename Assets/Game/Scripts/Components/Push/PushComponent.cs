using System;
using UnityEngine;

namespace Game
{
    public class PushComponent : MonoBehaviour
    {
        public event Action OnPush;
        
        private const int FORCE_MULTIPLIER = 100;

        [SerializeField] private float _forceStrength;
        [SerializeField] private Cooldown _cooldown;
        [SerializeField] private InteractableComponent _interactableComponent;


        private readonly Condition _condition = new();

        private void Update()
        {
            _cooldown.Tick(Time.deltaTime);
        }

        public void Invoke(Vector2 forceDirection, Vector2 lookAtDirection)
        {
            if (!_condition.IsTrue() || !_cooldown.IsTimeUp())
                return;

            _cooldown.Reset();
            OnPush?.Invoke();

            var target = _interactableComponent.GetInteractable(transform.position, lookAtDirection);
            if (!target) return;
            
            target.TryGetComponent(out Rigidbody2D rigidbody);
            rigidbody.AddForce(forceDirection.normalized * (_forceStrength * FORCE_MULTIPLIER));
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}