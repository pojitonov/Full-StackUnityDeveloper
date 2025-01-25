using System;
using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class CollisionEventListener : MonoBehaviour, IEventListener
    {
        public event Action<GameObject> OnEventTriggered;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            OnEventTriggered?.Invoke(other.gameObject);
        }
    }
}