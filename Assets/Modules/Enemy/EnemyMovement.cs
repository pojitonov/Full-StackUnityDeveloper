using UnityEngine;

namespace ShootEmUp
{
    public class EnemyMovement : IEnemyMovement
    {
        private readonly Enemy enemy;

        public EnemyMovement(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void Move()
        {
            Vector2 vector = enemy.destination - (Vector2) enemy.transform.position;
            if (vector.magnitude <= 0.25f)
            {
                enemy.isPointReached = true;
                return;
            }

            Vector2 direction = vector.normalized * Time.fixedDeltaTime;
            Vector2 nextPosition = enemy._rigidbody.position + direction * enemy.speed;
            enemy._rigidbody.MovePosition(nextPosition);
        }
    }
}