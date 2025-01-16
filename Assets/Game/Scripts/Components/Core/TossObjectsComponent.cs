using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class TossObjectsComponent : MonoBehaviour
    {
        public event Action OnTossed;

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

        public void Toss()
        {
            if (!_condition.IsTrue() || !_countdown.IsTimeUp())
                return;
            _countdown.Reset();
            
            var item = GamePhysics.GetInteractable(
                transform.position, 
                _lookAtComponent.GetDetectionRadius(), 
                _lookAtComponent.GetLayerMask(), 
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