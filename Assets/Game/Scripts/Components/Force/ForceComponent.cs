using System;
using Game.Scripts.Core;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class ForceComponent : MonoBehaviour
    {
        private const float FORCE_MULTIPLIER = 100;

        public event Action OnPush;
        public event Action OnToss;

        [SerializeField] private float _forceStrength;
        [SerializeField] private Cooldown cooldown;

        private readonly Condition _pushCondition = new();
        private readonly Condition _tossCondition = new();
        private InteractableDetectorComponent _interactableDetector;

        public void Init(InteractableDetectorComponent interactableDetector)
        {
            _interactableDetector = interactableDetector;
        }
        
        private void Update()
        {
            cooldown.Tick(Time.deltaTime);
        }

        public void ApplyForce(Vector2 forceDirection, Vector2 lookAtDirection)
        {
            var forceType = GetForceType(forceDirection);
            var condition = GetCondition(forceType);

            if (!condition.IsTrue() || !cooldown.IsTimeUp()) 
                return;

            cooldown.Reset();

            if (forceType == ForceType.Push)
                OnPush?.Invoke();
            else
                OnToss?.Invoke();

            var target = _interactableDetector.GetInteractable(transform.position, lookAtDirection);
            if (target && target.TryGetComponent(out Rigidbody2D rigidbody))
            {
                rigidbody.AddForce(forceDirection * (_forceStrength * FORCE_MULTIPLIER));
            }
        }

        private ForceType GetForceType(Vector2 forceDirection)
        {
            return forceDirection == Vector2.up ? ForceType.Toss : ForceType.Push;
        }

        private Condition GetCondition(ForceType forceType)
        {
            return forceType == ForceType.Push ? _pushCondition : _tossCondition;
        }

        public void AddCondition(Func<bool> condition, ForceType forceType)
        {
            var targetCondition = GetCondition(forceType);
            targetCondition.Add(condition);
        }
    }
}
