using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public class ShipHealthComponent
    {   
        [SerializeField]
        private int _health;
        
        public Action<Ship, int> OnHealthChanged;
        public Action<Ship> OnHealthEmpty;
        
        public int Health => _health;
        private readonly Ship _ship;

        public ShipHealthComponent(Ship ship, int health)
        {
            _ship = ship;
            _health = health;
        }
        
        public void TakeDamage(int damage)
        {
            if (_health <= 0)
                return;

            _health = Mathf.Max(0, _health - damage);
            OnHealthChanged?.Invoke(_ship, _health);
            if (_health <= 0)
                OnHealthEmpty?.Invoke(_ship);
        }
    }
}