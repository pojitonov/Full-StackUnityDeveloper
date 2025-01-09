using UnityEngine;

namespace Game.Scripts
{
    public sealed class Trampoline : MonoBehaviour
    {
        [SerializeField]
        private float _forceStrength = 1200f;

        private TossMechanic _tossMechanic;

        public void OnTriggerEnter2D(Collider2D other)
        {
            var rb = other.GetComponent<Rigidbody2D>();
            _tossMechanic = new TossMechanic(rb);
            _tossMechanic.Invoke(Vector2.up, _forceStrength);
        }
    }
}