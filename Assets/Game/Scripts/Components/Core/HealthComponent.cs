using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        public event Action OnHealthTaken;
        
        [field: ShowInInspector] public bool IsAlive { get; private set; } = true;
        
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
            
            Destroy();
        }

        public void Destroy()
        {
            IsAlive = false;
            gameObject.SetActive(false);
        }
    }
}