using UnityEngine;

namespace ShootEmUp
{
    public sealed class Enemy : Character
    {
        [SerializeField]
        private float countdown;

        private bool isPointReached;
        private Vector2 destination;
        private float currentTime;
        public Player Target { get; set; }

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
            Vector2 nextPosition = rigidbody2D.position + direction * speed;
            rigidbody2D.MovePosition(nextPosition);
        }

        private void Attack()
        {
            if (Target.Health <= 0) return;
            
            currentTime -= Time.fixedDeltaTime;

            if (currentTime <= 0)
            {
                Vector2 startPosition = firePoint.position;
                Vector2 vector = (Vector2)Target.transform.position - startPosition;
                Vector2 direction = vector.normalized;
                currentTime += countdown;

                SpawnBullet(startPosition, direction * 2, Color.red, (int)PhysicsLayer.ENEMY_BULLET);
            }
        }
    }
}