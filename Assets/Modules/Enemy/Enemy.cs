using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Enemy : MonoBehaviour
    {
        [SerializeField]
        public bool isPlayer;

        [SerializeField]
        public Transform firePoint;

        [SerializeField]
        public int health;

        [SerializeField]
        public Rigidbody2D _rigidbody;

        [SerializeField]
        public float speed = 5.0f;

        [SerializeField]
        public float countdown;

        [NonSerialized]
        public Player target;

        public Vector2 destination;
        public float currentTime;
        public bool isPointReached;
        
        private IEnemyMovement enemyMovement;
        private IEnemyAttack enemyAttack;
        
        private void Awake()
        {
            enemyMovement = new EnemyMovement(this);
            enemyAttack= new EnemyAttack(this);
        }

        private void FixedUpdate()
        {
            if (isPointReached)
            {
                enemyAttack.Attack();
            }
            else
            {
                enemyMovement.Move();
            }
        }

        public void Reset()
        {
            currentTime = countdown;
        }

        public void SetDestination(Vector2 endPoint)
        {
            destination = endPoint;
            isPointReached = false;
        }
        
        public void SubscribeToOnFire(Action<Vector2, Vector2> handler)
        {
            enemyAttack.OnFire += handler;
        }

        public void UnsubscribeFromOnFire(Action<Vector2, Vector2> handler)
        {
            enemyAttack.OnFire -= handler;
        }
    }
}