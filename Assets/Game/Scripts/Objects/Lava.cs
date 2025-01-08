using UnityEngine;

namespace Game.Scripts
{
    public sealed class Lava : MonoBehaviour
    {
        private KillMechanic _killMechanic;

        public void Awake()
        {
            _killMechanic = new KillMechanic();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            _killMechanic.OnTriggerEnter2D(other);
        }
    }
}