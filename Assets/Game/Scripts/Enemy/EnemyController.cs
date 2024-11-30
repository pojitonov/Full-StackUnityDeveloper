using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private BulletConfig bulletConfig;

        [SerializeField]
        private float countdown;

        private EnemyMovementComponent _movementComponent;
        private EnemyAttackComponent _attackComponent;
        private Ship ship;

        private void Awake()
        {
            ship = GetComponent<Ship>();
            _movementComponent = new EnemyMovementComponent(GetComponent<Rigidbody2D>());
            _attackComponent = new EnemyAttackComponent(countdown, bulletConfig, ship);
        }

        private void FixedUpdate()
        {
            _movementComponent.Move();
            if (_movementComponent.IsPointReached)
            {
                _attackComponent.Attack();
            }
        }

        public void SetDestination(Transform[] attackPositions)
        {
            _movementComponent.SetDestination(attackPositions);
        }

        public void SetTarget(Ship target)
        {
            _attackComponent.Target = target;
        }
    }
}