using UnityEngine;

namespace ShootEmUp
{
    public sealed class Ship : MonoBehaviour
    {
        [SerializeField]
        private bool isPlayer;

        [SerializeField]
        private int health;

        [SerializeField]
        private float speed = 5.0f;

        [SerializeField]
        private Transform firePoint;

        public ShipHealthComponent HealthComponent { get; private set; }
        private ShipMovementComponent _movementComponent;
        private ShipAttackComponent _attackComponent;

        private void Awake()
        {
            HealthComponent = new ShipHealthComponent(this, health);
            _movementComponent = new ShipMovementComponent(GetComponent<Rigidbody2D>(), speed);
            _attackComponent = new ShipAttackComponent(firePoint, isPlayer, FindAnyObjectByType<BulletManager>());
        }
        
        private void FixedUpdate()
        {
            _movementComponent.FixedUpdate();
        }

        public void SetDirection(int direction)
        {
            _movementComponent.SetDirection(direction);
        }

        public void Fire(Vector2 direction, BulletConfig bulletConfig)
        {
            _attackComponent.Fire(direction, bulletConfig);
        }

        public void TakeDamage(int damage)
        {
            HealthComponent.TakeDamage(damage);
        }
    }
}