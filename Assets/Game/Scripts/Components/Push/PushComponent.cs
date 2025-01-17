using System;
using Game.Scripts.Core;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushComponent : MonoBehaviour
    {
        public event Action OnPushed;

        [SerializeField] private float _forceStrength;
        [SerializeField] private Countdown _countdown;
        [SerializeField] private LookAtComponent _lookAtComponent;

        private readonly Condition _condition = new();

        private void Update()
        {
            _countdown.Tick(Time.deltaTime);
        }

        public void Push()
        {
            if (!_condition.IsTrue() || !_countdown.IsTimeUp())
                return;
            _countdown.Reset();

            var item = GamePhysics.GetInteractable(
                transform.position,
                _lookAtComponent.DetectionRadius,
                _lookAtComponent.LayerLayerMask,
                _lookAtComponent.Direction);

            GamePhysics.AddForceToInteractable(item, _lookAtComponent.Direction, _forceStrength);
            OnPushed?.Invoke();
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}