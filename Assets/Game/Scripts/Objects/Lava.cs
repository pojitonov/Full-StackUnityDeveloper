using UnityEngine;

namespace Game.Scripts
{
    public sealed class Lava : MonoBehaviour
    {
        private KillCharacterMechanic _killMechanic;

        public void Awake()
        {
            _killMechanic = new KillCharacterMechanic();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            _killMechanic.OnTriggerEnter2D(other);
        }
    }
}