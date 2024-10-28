using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Player : MonoBehaviour
    {
        public Action<Player, int> OnHealthChanged;
        public Action<Player> OnHealthEmpty;

        [SerializeField]
        private bool isPlayer;

        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private int health;

        [SerializeField]
        private float speed = 5.0f;

        public bool IsPlayer => isPlayer;
        public Transform FirePoint => firePoint;

        public int Health
        {
            get => health;
            set => health = value;
        }

        public float Speed => speed;

        public Rigidbody2D Rigidbody2D { get; private set; }

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}