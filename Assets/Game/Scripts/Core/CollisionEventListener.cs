using System;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class CollisionEventListener : MonoBehaviour
    {
        public event Action<Collider2D> OnTrigger;
        public event Action<Collision2D> OnCollision;
        
        [SerializeField] private bool _colliderIsTrigger;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_colliderIsTrigger)
                return;
            OnTrigger?.Invoke(other);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_colliderIsTrigger)
                return;
            OnCollision?.Invoke(other);
        }
    }
}