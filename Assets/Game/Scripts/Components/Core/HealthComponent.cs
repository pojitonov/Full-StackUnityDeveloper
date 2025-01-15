using System;
using Game.Scripts.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        public event Action OnDamaged;
        
        [field: ShowInInspector] public bool IsAlive { get; private set; } = true;
        
        [SerializeField] private int _maxLife = 5;
        [SerializeField] private int _currentLife;
        [SerializeField] private Countdown _delay;

        private void Awake()
        {
            _delay.OnTimeIsUp += Destroy;
            _currentLife = _maxLife;
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
            _currentLife -= damage;
            OnDamaged?.Invoke();

            if (_currentLife > 0) return;
            IsAlive = false;
            _delay.Reset();
        }

        public void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}