using UnityEngine;

namespace Game.Scripts
{
    public sealed class Trampoline : MonoBehaviour
    {
        [SerializeField]
        private float _forceStrength = 12f;

        private PushMechanic _pushMechanic;

        public void OnTriggerEnter2D(Collider2D other)
        {
            var rigidbody = other.GetComponent<Rigidbody2D>();
            _pushMechanic = new PushMechanic(rigidbody);
            _pushMechanic.Invoke(Vector2.up, _forceStrength);
        }
    }
}