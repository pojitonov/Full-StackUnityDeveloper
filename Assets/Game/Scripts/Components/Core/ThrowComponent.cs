using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public sealed class ThrowComponent : MonoBehaviour
    {
        public event Action OnThrown;

        [SerializeField] private Vector2 _forceDirection = Vector2.up;
        [SerializeField] private float _forceStrength = 10f;
        
        private GamePhysics _gamePhysics;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Rigidbody2D rigidbody)) 
                return;
            Throw(_forceDirection, _forceStrength, rigidbody);
        }

        private void Throw(Vector2 direction, float force, Rigidbody2D rigidbody)
        {
            GamePhysics.AddForce(rigidbody, direction, force);
            OnThrown?.Invoke();
        }
    }
}