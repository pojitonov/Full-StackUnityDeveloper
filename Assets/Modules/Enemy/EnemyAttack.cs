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
            if (enemy.target.health <= 0)
            {
                return;
            }

            enemy.currentTime -= Time.fixedDeltaTime;

            if (enemy.currentTime <= 0)
            {
                Vector2 startPosition = enemy.firePoint.position;
                Vector2 vector = (Vector2)enemy.target.transform.position - startPosition;
                Vector2 direction = vector.normalized;
                OnFire?.Invoke(startPosition, direction);
                enemy.currentTime += enemy.countdown;
            }
        }
    }
}