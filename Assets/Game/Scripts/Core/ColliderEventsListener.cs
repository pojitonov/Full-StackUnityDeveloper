using System;
using UnityEngine;

namespace Game
{
    public class ColliderEventsListener : MonoBehaviour
    {
        public event Action<GameObject> OnEventTriggered;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            OnEventTriggered?.Invoke(other.gameObject);
        }
    }
}