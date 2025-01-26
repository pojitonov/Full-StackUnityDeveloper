using System;
using UnityEngine;

namespace Game.Scripts.Components
{
    public sealed class ThrowComponent : MonoBehaviour
    {
        public event Action OnThrown;

        [SerializeField] private Vector2 _forceDirection = Vector2.up;
        [SerializeField] private float _forceStrength = 10f;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Rigidbody2D rigidbody))
                return;

            rigidbody.AddForce(_forceDirection * _forceStrength, ForceMode2D.Impulse);
            OnThrown?.Invoke();
        }
    }
}