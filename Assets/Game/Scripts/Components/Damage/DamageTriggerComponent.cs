using System;
using Game.Scripts.Core;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class DamageTriggerComponent : MonoBehaviour
    {
        public event Action<GameObject> OnDamageTriggered;

        [SerializeField] private CollisionEventListener _collisionEventListener;

        private void OnEnable()
        {
            _collisionEventListener.OnTrigger += OnTrigger;
            _collisionEventListener.OnCollision += OnCollision;
        }

        private void OnDisable()
        {
            _collisionEventListener.OnTrigger -= OnTrigger;
            _collisionEventListener.OnCollision -= OnCollision;
        }

        private void OnTrigger(Collider2D other)
        {
            OnDamageTriggered?.Invoke(other.gameObject);
        }

        private void OnCollision(Collision2D other)
        {
            OnDamageTriggered?.Invoke(other.gameObject);
        }
    }
}