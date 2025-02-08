using System;
using UnityEngine;

namespace Game
{
    public class ForceComponent : MonoBehaviour
    {
        public event Action OnForceApplied;

        private const int FORCE_MULTIPLIER = 100;

        [SerializeField] private float _forceStrength;

        public void ApplyForce(GameObject gameObject, Vector2 forceDirection)
        {
            if (!gameObject) return;
            if (!gameObject.TryGetComponent(out Rigidbody2D rigidbody)) return;
            
            rigidbody.AddForce(forceDirection.normalized * (_forceStrength * FORCE_MULTIPLIER));
            OnForceApplied?.Invoke();
        }

        public void ApplyForce(GameObject gameObject) => ApplyForce(gameObject, Vector2.up);
    }
}