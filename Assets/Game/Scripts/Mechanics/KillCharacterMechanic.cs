using UnityEngine;

namespace Game.Scripts
{
    public class KillCharacterMechanic
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Character character))
            {
                character._isAlive = false;
                character.gameObject.SetActive(false);
            }
        }
    }
}