using System;
using Game.Scripts.Common;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        public event Action OnDamaged;
        
        [field: ShowInInspector] public bool IsAlive { get; private set; } = true;
        
        [SerializeField] private int _maxLife = 5;
        [SerializeField] private int _currentLife;
        [SerializeField] private Countdown _countdown;

        private void Awake()
        {
            _countdown.OnTimeIsUp += Destroy;
            _currentLife = _maxLife;
        }

        private void OnDestroy()
        {
            _countdown.OnTimeIsUp -= Destroy;
        }

        public void Update()
        {
            if (!IsAlive) 
                _countdown.Tick(Time.deltaTime);
        }

        public void TakeDamage(int damage)
        {
            _currentLife -= damage;
            OnDamaged?.Invoke();
            _countdown.Reset();

            if (_currentLife > 0) 
                return;
            IsAlive = false;
        }

        public void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}