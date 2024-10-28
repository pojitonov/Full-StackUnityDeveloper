using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Character : MonoBehaviour
    {
        public Action<Character, int> OnHealthChanged;
        public Action<Character> OnHealthEmpty;
        
        [SerializeField]
        private bool isPlayer;

        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private int health;

        [SerializeField]
        private float speed = 5.0f;

        [SerializeField]
        private float countdown;

        private IMovable characterMovement;
        private IAttackable characterAttack;

        public bool IsPlayer => isPlayer;
        public Transform FirePoint => firePoint;

        public int Health
        {
            get => health;
            set => health = value;
        }

        public float Speed => speed;
        public float Countdown => countdown;
        public float CurrentTime { get; set; }
        public bool IsPointReached { get; set; }
        public Player Target { get; set; }
        public Vector2 Destination { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            characterMovement = new CharacterMovement(this);
            characterAttack = new CharacterAttack(this);
        }

        private void FixedUpdate()
        {
            if (IsPointReached)
            {
                characterAttack.Attack();
            }
            else
            {
                characterMovement.Move();
            }
        }

        public void Reset()
        {
            CurrentTime = countdown;
        }

        public void SetDestination(Vector2 endPoint)
        {
            Destination = endPoint;
            IsPointReached = false;
        }

        public void SubscribeToOnFire(Action<Vector2, Vector2> handler)
        {
            characterAttack.OnFire += handler;
        }

        public void UnsubscribeFromOnFire(Action<Vector2, Vector2> handler)
        {
            characterAttack.OnFire -= handler;
        }
    }
}