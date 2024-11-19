using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttack : MonoBehaviour
    {
        [SerializeField]
        private float countdown;
        [SerializeField]
        private BulletConfig bulletConfig;
        [SerializeField]
        private Ship ship;
        [SerializeField]
        private EnemyMovement enemyMovement;
        private float currentTime;

        public Ship Target { get; set; }
        
        private void FixedUpdate()
        {
            if (enemyMovement.IsPointReached)
            {
                Attack();
            }
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