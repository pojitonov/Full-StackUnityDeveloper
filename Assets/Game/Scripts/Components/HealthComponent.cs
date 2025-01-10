using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts
{
    public class HealthComponent : MonoBehaviour, ITriggerable
    {
        public event Action OnStateChanged;

        [field: ShowInInspector] [field: ReadOnly]
        public bool IsAlive { get; private set; } = true;

        [SerializeField]
        private int _lifePoints = 5;

        [SerializeField]
        private int _damagePoints;

        [SerializeField]
        private Countdown _delay;

        private void Awake()
        {
            _delay.OnTimeIsUp += Destroy;
        }

        private void OnDestroy()
        {
            _delay.OnTimeIsUp -= Destroy;
        }

        public void Update()
        {
            if (!IsAlive) _delay.Tick(Time.deltaTime);
        }

        public void TakeDamage(int damage)
        {
            _damagePoints += damage;
            OnStateChanged?.Invoke();

            if (_damagePoints >= _lifePoints)
            {
                IsAlive = false;
                _delay.Reset();
            }
        }

        public void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}