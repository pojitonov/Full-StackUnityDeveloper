using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttack
    {
        private readonly float countdown;
        private readonly BulletConfig bulletConfig;
        private readonly Ship ship;
        private float currentTime;

        public Ship Target { get; set; }

        public EnemyAttack(float countdown, BulletConfig bulletConfig, Ship ship)
        {
            this.countdown = countdown;
            this.bulletConfig = bulletConfig;
            this.ship = ship;
        }

        public void Attack()
        {
            if (Target.Health <= 0) return;

            currentTime -= Time.fixedDeltaTime;

            if (currentTime <= 0)
            {
                Vector2 targetPosition = Target.transform.position;
                currentTime += countdown;
                Vector2 direction = (targetPosition - (Vector2)ship.transform.position).normalized;
                ship.Fire(direction, bulletConfig);
            }
        }
    }
}