using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public class HealthComponent : MonoBehaviour
    {
        public event Action OnStateChanged;
        public event Action<bool> OnDie;

        [ShowInInspector, ReadOnly]
        private bool _isAlive;

        [SerializeField]
        private int _lifePoints = 5;

        [SerializeField]
        private int _damagePoints;

        public void TakeDamage(int damage)
        {
            _damagePoints += damage;
            OnStateChanged?.Invoke();

            if (_damagePoints >= _lifePoints)
            {
                Die();
            }
        }

        private void Die()
        {
            _isAlive = false;
            gameObject.SetActive(false);
            OnDie?.Invoke(_isAlive);
        }
    }
}