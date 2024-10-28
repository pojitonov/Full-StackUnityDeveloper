using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnWorkCompleted;

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
            HandleCollision(collision);
        }
        
        public void Initialize(Vector2 position, Color color, int physicsLayer, int damage, bool isPlayer, Vector2 velocity)
        {
            this.isPlayer = isPlayer;
            this.damage = damage;
            transform.position = position;
            gameObject.layer = physicsLayer;
            spriteRenderer.color = color;
            rigidbody2D.velocity = velocity;
        }
        
        private void HandleCollision(Collision2D collision)
        {
            GameObject other = collision.gameObject;
            
            if (damage <= 0)
                return;

            if (other.TryGetComponent(out Player player))
            {
                if (isPlayer != player.IsPlayer)
                {
                    if (player.Health <= 0)
                        return;

                    player.Health = Mathf.Max(0, player.Health - damage);
                    player.OnHealthChanged?.Invoke(player, player.Health);

                    if (player.Health <= 0)
                        player.OnHealthEmpty?.Invoke(player);
                }
            }
            else if (other.TryGetComponent(out Enemy enemy))
            {
                if (isPlayer != enemy.IsPlayer)
                {
                    if (enemy.Health > 0)
                    {
                        enemy.Health = Mathf.Max(0, enemy.Health - damage);
                    }
                }
            }
            OnWorkCompleted?.Invoke(this);
        }
    }
}