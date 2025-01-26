using System;
using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class DamageTriggerComponent : MonoBehaviour
    {
        public event Action<GameObject> OnDamageTriggered;

        [SerializeField] private MonoBehaviour _eventListener;
        
        private IEventListener _listener;

        private void Awake()
        {
            if (_eventListener is IEventListener eventListener) 
                _listener = eventListener;
            else
                Debug.LogWarning($"The {_eventListener} component does not implement IEventListener!");
        }

        private void OnEnable()
        {
            _listener.OnEventTriggered += HandleEvent;
        }

        private void OnDisable()
        {
            _listener.OnEventTriggered -= HandleEvent;
        }

        private void HandleEvent(GameObject other)
        {
            OnDamageTriggered?.Invoke(other);
        }
    }
}