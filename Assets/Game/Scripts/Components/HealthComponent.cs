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

        public void TakeDamage(int damage)
        {
            _damagePoints += damage;
            OnStateChanged?.Invoke();

            if (_damagePoints >= _lifePoints)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            IsAlive = false;
            gameObject.SetActive(false);
        }
    }
}