using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushObjectsComponent : MonoBehaviour
    {
        public event Action OnPushed;

        [SerializeField] private float _forceStrength;
        [SerializeField] private Countdown _countdown;

        private LookAtComponent _lookAtComponent;
        private readonly Condition _condition = new();

        private void Awake()
        {
            _lookAtComponent = GetComponent<LookAtComponent>();
        }

        private void Update()
        {
            _countdown.Tick(Time.deltaTime);
        }

        public void Push()
        {
            if (!_condition.IsTrue() || !_countdown.IsTimeUp())
                return;
            _countdown.Reset();

            var items = _lookAtComponent.GetInteractable();
            var direction = _lookAtComponent.Direction;
            
            GamePhysics.AddForceToInteractable(items, direction, _forceStrength);
            OnPushed?.Invoke();
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}