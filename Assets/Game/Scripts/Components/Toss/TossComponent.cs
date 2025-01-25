using System;
using Game.Scripts.Core;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class TossComponent : MonoBehaviour
    {
        public event Action OnTossed;

        [SerializeField] private float _forceStrength;
        [SerializeField] private Cooldown cooldown;
        [SerializeField] private LookAtComponent _lookAtComponent;
        
        private readonly Condition _condition = new();

        private void Update()
        {
            cooldown.Tick(Time.deltaTime);
        }

        public void Toss()
        {
            if (!_condition.IsTrue() || !cooldown.IsTimeUp())
                return;
            cooldown.Reset();

            var item = GamePhysics.GetInteractable(
                transform.position,
                _lookAtComponent.DetectionRadius,
                _lookAtComponent.LayerLayerMask,
                _lookAtComponent.Direction);

            GamePhysics.AddForceToInteractable(item, Vector2.up, _forceStrength);
            OnTossed?.Invoke();
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.Add(condition);
        }
    }
}