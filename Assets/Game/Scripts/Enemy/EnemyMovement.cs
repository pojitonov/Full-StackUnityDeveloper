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
            Vector2 vector = enemy.Destination - (Vector2) enemy.transform.position;
            if (vector.magnitude <= 0.25f)
            {
                enemy.IsPointReached = true;
                return;
            }

            Vector2 direction = vector.normalized * Time.fixedDeltaTime;
            Vector2 nextPosition = enemy.Rigidbody2D.position + direction * enemy.Speed;
            enemy.Rigidbody2D.MovePosition(nextPosition);
        }
    }
}