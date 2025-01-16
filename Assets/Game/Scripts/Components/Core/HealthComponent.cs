using System;
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

        private void Awake()
        {
            _currentLife = _maxLife;
        }
        
        public void TakeDamage(int damage)
        {
            _currentLife -= damage;
            OnDamaged?.Invoke();

            if (_currentLife > 0) 
                return;
            
            IsAlive = false;
            Destroy();
        }

        public void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}