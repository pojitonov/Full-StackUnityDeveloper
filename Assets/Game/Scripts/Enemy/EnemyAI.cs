using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAI : MonoBehaviour
    {
        [SerializeField]
        private float countdown;
        
        [SerializeField]
        private BulletConfig bulletConfig;
        
        public Ship Target { get; set; }
        
        private bool isPointReached;
        private Vector2 destination;
        private float currentTime;
        private new Rigidbody2D rigidbody2D;
        private Ship ship;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            ship = GetComponent<Ship>();
        }
        
        private void FixedUpdate()
        {
            Move();
            if (isPointReached)
            {
                Attack();
            }
        }

        public void SetRandomDestination(Transform[] attackPositions)
        {
            int index = Random.Range(0, attackPositions.Length);
            destination = attackPositions[index].position;
            isPointReached = false;
        }

        private void Move()
        {
            Vector2 vector = destination - (Vector2)transform.position;
            if (vector.magnitude <= 0.25f)
            {
                isPointReached = true;
                return;
            }

            Vector2 direction = vector.normalized * Time.fixedDeltaTime;
            Vector2 nextPosition = rigidbody2D.position + direction * 5.0f;
            rigidbody2D.MovePosition(nextPosition);
        }

        private void Attack()
        {
            if (Target.Health <= 0) return;
        
            currentTime -= Time.fixedDeltaTime;
        
            if (currentTime <= 0)
            {
                Vector2 targetPosition = Target.transform.position;
                currentTime += countdown;
                Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
                ship.Fire(direction, bulletConfig);
            }
        }
    }
}