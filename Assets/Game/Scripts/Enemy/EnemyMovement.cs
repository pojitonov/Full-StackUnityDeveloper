using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMovement : MonoBehaviour
    {
        [SerializeField]
        private new Rigidbody2D rigidbody2D;
        private Vector2 destination;

        public bool IsPointReached { get; set; }
        
        private void FixedUpdate()
        {
            Move();
        }

        public void SetDestination(Transform[] attackPositions)
        {
            int index = Random.Range(0, attackPositions.Length);
            destination = attackPositions[index].position;
            IsPointReached = false;
        }

        private void Move()
        {
            Vector2 vector = destination - (Vector2)transform.position;
            if (vector.magnitude <= 0.25f)
            {
                IsPointReached = true;
                return;
            }

            Vector2 direction = vector.normalized * Time.fixedDeltaTime;
            Vector2 nextPosition = rigidbody2D.position + direction * 5.0f;
            rigidbody2D.MovePosition(nextPosition);
        }
    }
}