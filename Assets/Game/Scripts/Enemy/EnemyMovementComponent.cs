using UnityEngine;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    public sealed class EnemyMovementComponent
    {
        private readonly Rigidbody2D rigidbody2D;
        private Vector2 destination;

        public bool IsPointReached { get; private set; }

        public EnemyMovementComponent(Rigidbody2D rigidbody2D)
        {
            this.rigidbody2D = rigidbody2D;
        }

        public void Move()
        {
            Vector2 vector = destination - rigidbody2D.position;
            if (vector.magnitude <= 0.25f)
            {
                IsPointReached = true;
                return;
            }

            Vector2 direction = vector.normalized * Time.fixedDeltaTime;
            Vector2 nextPosition = rigidbody2D.position + direction * 5.0f;
            rigidbody2D.MovePosition(nextPosition);
        }

        public void SetDestination(Transform[] attackPositions)
        {
            int index = Random.Range(0, attackPositions.Length);
            destination = attackPositions[index].position;
            IsPointReached = false;
        }
    }
}