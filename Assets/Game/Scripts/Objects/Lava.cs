using UnityEngine;

namespace Game.Scripts
{
    public sealed class Lava : MonoBehaviour
    {
        private DestroyMechanic _destroyMechanic;

        public void Awake()
        {
            _destroyMechanic = new DestroyMechanic();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            _destroyMechanic.OnTriggerEnter2D(other);
        }
    }
}