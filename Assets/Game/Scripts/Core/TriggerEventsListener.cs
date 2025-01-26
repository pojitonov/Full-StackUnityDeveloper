using System;
using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class TriggerEventsListener : MonoBehaviour, IEventListener
    {
        public event Action<GameObject> OnEventTriggered;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnEventTriggered?.Invoke(other.gameObject);
        }
    }
}