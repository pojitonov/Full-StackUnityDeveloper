using System;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyAttack : IEnemyAttack
    {
        public event Action<Vector2, Vector2> OnFire;

        private readonly Enemy enemy;

        public EnemyAttack(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void Attack()
        {
            if (enemy.Target.Health <= 0)
            {
                return;
            }

            enemy.CurrentTime -= Time.fixedDeltaTime;

            if (enemy.CurrentTime <= 0)
            {
                Vector2 startPosition = enemy.FirePoint.position;
                Vector2 vector = (Vector2)enemy.Target.transform.position - startPosition;
                Vector2 direction = vector.normalized;
                OnFire?.Invoke(startPosition, direction);
                enemy.CurrentTime += enemy.Countdown;
            }
        }
    }
}