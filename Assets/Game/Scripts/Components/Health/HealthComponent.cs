using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public class HealthComponent : MonoBehaviour
    {
        public event Action OnHealthTaken;
        public event Action OnDied;
        
        [field: ShowInInspector] public bool IsAlive { get; set; } = true;
        
        [SerializeField] private int _maxLife = 5;
        [SerializeField] private int _currentLife;

        private void Awake()
        {
            _currentLife = _maxLife;
        }
        
        public void TakeDamage(int damage)
        {
            _currentLife -= damage;
            OnHealthTaken?.Invoke();

            if (_currentLife > 0) 
                return;
            
            IsAlive = false;
            OnDied?.Invoke();
        }
    }
}