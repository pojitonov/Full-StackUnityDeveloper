using System;
using Game.Scripts.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Components
{
    public class DamageComponent : MonoBehaviour
    {
        public event Action<GameObject> OnDamaged;

        [SerializeField] private int _damagePoints = 1;
        [FormerlySerializedAs("_countdown")]
        [SerializeField] private Cooldown cooldown;
        [SerializeField] private CollisionEventListener collisionEventListener;

        private void Update()
        {
            cooldown.Tick(Time.deltaTime);
        }
        
        private void OnEnable()
        {
            collisionEventListener.OnTrigger += OnTrigger;
            collisionEventListener.OnCollision += OnCollision;
        }
        
        private void OnDisable()
        {
            collisionEventListener.OnTrigger -= OnTrigger;
            collisionEventListener.OnCollision -= OnCollision;
        }
        
        private void OnTrigger(Collider2D other)
        {
            if (!cooldown.IsTimeUp())
                return;
            ApplyDamage(other.gameObject);
        }

        private void OnCollision(Collision2D other)
        {
            if (!cooldown.IsTimeUp())
                return;
            ApplyDamage(other.gameObject);
        }

        private void ApplyDamage(GameObject other)
        {
            var health = other.GetComponentInParent<HealthComponent>();
            if (health == null)
                return;
            health.TakeDamage(_damagePoints);
            cooldown.Reset();
            OnDamaged?.Invoke(other);
        }
    }
}