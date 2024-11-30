using UnityEngine;

namespace ShootEmUp
{
    public sealed class Ship : MonoBehaviour
    {
        [SerializeField]
        private bool isPlayer;

        [SerializeField]
        private ShipMovementComponent _movementComponent;
        
        [SerializeField]
        private ShipAttackComponent _attackComponent;
        
        [SerializeField]
        private ShipHealthComponent _healthComponent;
        public ShipHealthComponent HealthComponent { get; private set; }

        private void Awake()
        {
            HealthComponent = new ShipHealthComponent(this, _healthComponent.Health);
            _movementComponent = new ShipMovementComponent(GetComponent<Rigidbody2D>());
            _attackComponent = new ShipAttackComponent(_attackComponent.FirePoint, isPlayer, FindAnyObjectByType<BulletManager>());
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