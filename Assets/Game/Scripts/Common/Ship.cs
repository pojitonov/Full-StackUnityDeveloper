using System;
using UnityEngine;

namespace ShootEmUp
{
    public class Ship : MonoBehaviour
    {
        public Action<Ship, int> OnHealthChanged;
        public Action<Ship> OnHealthEmpty;
        public int Health => health;

        private BulletManager bulletManager;
        private bool isFiring;
        private int moveDirection;

        [SerializeField]
        private bool isPlayer;

        [SerializeField]
        internal Transform firePoint;

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

            if (isFiring)
            {
                Attack();
                isFiring = false;
            }
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

        public void SetMoveDirection(int direction)
        {
            moveDirection = direction;
        }

        public void SetFiring(bool firing)
        {
            isFiring = firing;
        }

        public void Fire(Vector2 position, Vector2 direction, Color color, int layer)
        {
            bulletManager.SpawnBullet(position, color, layer, 1, isPlayer, direction);
        }

        private void Move(float direction)
        {
            Vector2 moveDirection = new Vector2(direction, 0);
            Vector2 moveStep = moveDirection * (Time.fixedDeltaTime * speed);
            Vector2 targetPosition = rigidbody2D.position + moveStep;
            rigidbody2D.MovePosition(targetPosition);
        }

        private void Attack()
        {
            Vector2 startPosition = firePoint.position;
            Vector2 direction = firePoint.rotation * Vector3.up;

            Fire(startPosition, direction * 3, Color.blue, (int)PhysicsLayer.PLAYER_BULLET);
        }
    }
}