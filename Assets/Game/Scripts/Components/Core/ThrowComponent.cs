using System;
using UnityEngine;

namespace Game.Scripts
{
    public sealed class ThrowComponent : MonoBehaviour
    {
        public event Action OnThrown;

        [SerializeField] private Vector2 _forceDirection = Vector2.up;
        [SerializeField] private float _forceStrength = 10f;
        
        private const float _multiplier = 100;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Rigidbody2D rigidbody)) 
                return;
            Throw(_forceDirection, _forceStrength, rigidbody);
        }

        private void Throw(Vector2 direction, float force, Rigidbody2D rigidbody)
        {
            rigidbody.AddForce(direction.normalized * force * _multiplier);
            OnThrown?.Invoke();
        }
    }
}