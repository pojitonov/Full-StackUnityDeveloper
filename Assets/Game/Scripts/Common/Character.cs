using UnityEngine;

namespace ShootEmUp
{
    public abstract class Character : MonoBehaviour
    {
        protected BulletManager bulletManager;

        [SerializeField]
        protected bool isPlayer;

        [SerializeField]
        protected Transform firePoint;

        [SerializeField]
        protected int health;

        [SerializeField]
        protected float speed = 5.0f;

        protected Rigidbody2D rigidbody2D;
        public bool IsPlayer => isPlayer;

        public int Health
        {
            get => health;
            set => health = value;
        }

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            bulletManager = FindAnyObjectByType<BulletManager>();
        }
        
        protected void SpawnBullet(Vector2 position, Vector2 direction, Color color, int layer)
        {
            bulletManager.SpawnBullet(position, color, layer, 1, isPlayer, direction);
        }
    }
}