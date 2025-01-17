using System;
using Game.Scripts.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Components
{
    public class PushComponent : MonoBehaviour
    {
        public event Action OnPushed;

        [SerializeField] private float _forceStrength;
        [SerializeField] private Cooldown cooldown;
        [SerializeField] private LookAtComponent _lookAtComponent;

        private readonly Condition _condition = new();

        private void Update()
        {
            cooldown.Tick(Time.deltaTime);
        }

        public void Push()
        {
            if (!_condition.IsTrue() || !cooldown.IsTimeUp())
                return;
            cooldown.Reset();

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