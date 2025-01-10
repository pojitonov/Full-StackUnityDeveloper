using System;
using Sirenix.OdinInspector;
using UnityEngine;

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
        private Countdown _countdown;

        private void Awake()
        {
            _countdown.OnTimeIsUp += Destroy;
        }

        private void OnDestroy()
        {
            _countdown.OnTimeIsUp -= Destroy;
        }

        public void Update()
        {
            if (!IsAlive) _countdown.Tick(Time.deltaTime);
        }

        public void TakeDamage(int damage)
        {
            _damagePoints += damage;
            OnStateChanged?.Invoke();

            if (_damagePoints >= _lifePoints)
            {
                IsAlive = false;
                _countdown.Reset();
            }
        }

        public void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}