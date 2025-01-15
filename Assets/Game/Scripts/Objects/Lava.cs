using System;
using UnityEngine;

namespace Game.Scripts
{
    public sealed class Lava : MonoBehaviour
    {
        public event Action OnStateChanged;
        
        private DestroyMechanic _destroyMechanic;

        public void Awake()
        {
            _destroyMechanic = new DestroyMechanic();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            _destroyMechanic.OnTriggerEnter2D(other);
            OnStateChanged?.Invoke();
        }
    }
}