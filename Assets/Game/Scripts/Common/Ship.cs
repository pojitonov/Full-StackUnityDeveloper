using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Ship : MonoBehaviour
    {
        public Action<Ship, int> OnHealthChanged;
        public Action<Ship> OnHealthEmpty;
        public int Health => health;

        private BulletManager bulletManager;
        private int moveDirection;

        [SerializeField]
        private bool isPlayer;

        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private int health;

        [SerializeField]
        private float speed = 5.0f;

        private new Rigidbody2D rigidbody2D;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            bulletManager = FindAnyObjectByType<BulletManager>();
        }

        private void FixedUpdate()
        {
            Move(moveDirection);
        }

        public void TakeDamage(int damage)
        {
            if (health <= 0)
                return;

            health = Mathf.Max(0, health - damage);
            OnHealthChanged?.Invoke(this, health);
            if (health <= 0)
                OnHealthEmpty?.Invoke(this);
        }

        public void SetDirection(int direction)
        {
            moveDirection = direction;
        }

        public void Fire(Vector2 direction, BulletConfig bulletConfig)
        {
            Vector2 firePosition = firePoint.position;
            bulletManager.SpawnBullet(firePosition, 1, isPlayer, direction * bulletConfig.speed, bulletConfig.color, bulletConfig.layer);
        }

        private void Move(float direction)
        {
            Vector2 moveDirection = new Vector2(direction, 0);
            Vector2 moveStep = moveDirection * (Time.fixedDeltaTime * speed);
            Vector2 targetPosition = rigidbody2D.position + moveStep;
            rigidbody2D.MovePosition(targetPosition);
        }
    }
}