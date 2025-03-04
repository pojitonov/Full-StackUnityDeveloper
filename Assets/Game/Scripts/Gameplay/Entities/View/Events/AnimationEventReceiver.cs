using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    public sealed class AnimationEventReceiver : MonoBehaviour
    {
        public event Action<string> OnEvent;
        
        [SerializeField] private EcsView _view;
        [SerializeField] string _animationEvent = "OnAttackAnimation";
        
        private readonly Dictionary<string, Action> _handlers = new();

        public void Awake()
        {
            Subscribe(_animationEvent, OnAnimation);
        }

        private void OnDestroy()
        {
            Unsubscribe(_animationEvent, OnAnimation);
        }

        private void OnAnimation()
        {
            var animationEvent = EcsAdmin.Systems.GetWorld().GetEvent<AnimationEvent>();
            animationEvent.Fire(new AnimationEvent { entity = _view.GetPackedEntity() });
        }

        [UsedImplicitly]
        private void ReceiveEvent(string message)
        {
            if (_handlers.TryGetValue(message, out Action handler)) 
                handler.Invoke();

            OnEvent?.Invoke(message);
        }

        public void Subscribe(string evt, Action action)
        {
            if (_handlers.TryGetValue(evt, out Action handler))
                handler += action;
            else
                handler = action;

            _handlers[evt] = handler;
        }

        public void Unsubscribe(string evt, Action action)
        {
            if (_handlers.TryGetValue(evt, out Action handler))
            {
                handler -= action;
                _handlers[evt] = handler;
            }
        }
    }
}