using System;
using UnityEngine;

namespace Game.Scripts
{
    public sealed class Trampoline : MonoBehaviour, ITriggerable
    {
        public event Action OnStateChanged;

        [SerializeField] private Vector2 _forceDirection = Vector2.up;
        [SerializeField] private float _forceStrength = 10f;

        private PushMechanic _pushMechanic;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var rigidbody = other.GetComponent<Rigidbody2D>();
            _pushMechanic = new PushMechanic(rigidbody);
            _pushMechanic.Invoke(_forceDirection, _forceStrength);

            if (other.CompareTag("Character"))
            {
                OnStateChanged?.Invoke();
            }
        }
    }
}