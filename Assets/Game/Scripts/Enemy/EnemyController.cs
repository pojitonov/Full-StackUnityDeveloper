using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private BulletConfig bulletConfig;

        [SerializeField]
        private float countdown;

        private EnemyMovement movement;
        private EnemyAttack attack;
        private Ship ship;

        private void Awake()
        {
            ship = GetComponent<Ship>();
            movement = new EnemyMovement(GetComponent<Rigidbody2D>());
            attack = new EnemyAttack(countdown, bulletConfig, ship);
        }

        private void FixedUpdate()
        {
            movement.Move();
            if (movement.IsPointReached)
            {
                attack.Attack();
            }
        }

        public void SetDestination(Transform[] attackPositions)
        {
            movement.SetDestination(attackPositions);
        }

        public void SetTarget(Ship target)
        {
            attack.Target = target;
        }
    }
}