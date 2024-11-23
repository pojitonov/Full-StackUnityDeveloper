using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Ship : MonoBehaviour
    {
        public Action<Ship, int> OnHealthChanged;
        public Action<Ship> OnHealthEmpty;
        [SerializeField]
        private int health;

        [SerializeField]
        private bool isPlayer;

        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private float speed = 5.0f;

        private ShipMovement movement;
        private ShipAttack attack;
        
        public int Health => health;

        private void Awake()
        {
            movement = new ShipMovement(GetComponent<Rigidbody2D>(), speed);
            attack = new ShipAttack(firePoint, isPlayer, FindAnyObjectByType<BulletManager>());
        }

        private void FixedUpdate()
        {
            movement.FixedUpdate();
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

        public void Fire(Vector2 direction, BulletConfig bulletConfig)
        {
            attack.Fire(direction, bulletConfig);
        }
        
        public void SetDirection(int direction)
        {
            movement.SetDirection(direction);
        }
    }
}