using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnCompleted;

        private bool isPlayer;
        private int damage;
        private new Rigidbody2D rigidbody2D;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            HandleDamage(collision);
        }

        public void Initialize(Vector2 position, Color color, int physicsLayer, int damage, bool isPlayer,
            Vector2 velocity)
        {
            this.isPlayer = isPlayer;
            this.damage = damage;
            transform.position = position;
            gameObject.layer = physicsLayer;
            spriteRenderer.color = color;
            rigidbody2D.velocity = velocity;
        }

        private void HandleDamage(Collision2D collision)
        {
            GameObject other = collision.gameObject;

            if (damage <= 0)
                return;

            if (other.TryGetComponent(out Ship ship))
            {
                ship.TakeDamage(damage);
            }

            OnCompleted?.Invoke(this);
        }
    }
}