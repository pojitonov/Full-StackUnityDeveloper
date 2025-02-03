using System;
using UnityEngine;

namespace Game
{
    public class TriggerEventsListener : MonoBehaviour
    {
        public event Action<GameObject> OnEventTriggered;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnEventTriggered?.Invoke(other.gameObject);
        }
    }
}