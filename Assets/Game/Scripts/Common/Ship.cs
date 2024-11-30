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
        private Transform firePoint;

        [SerializeField]
        private ShipMovementComponent _movementComponent;
        public ShipHealthComponent HealthComponent { get; private set; }
        private ShipAttackComponent _attackComponent;

        private void Awake()
        {
            HealthComponent = new ShipHealthComponent(this, health);
            _movementComponent = new ShipMovementComponent(GetComponent<Rigidbody2D>());
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