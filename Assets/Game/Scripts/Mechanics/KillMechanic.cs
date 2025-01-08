using UnityEngine;

namespace Game.Scripts
{
    public class KillMechanic
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<IKillable>(out var killable))
            {
                killable.Kill();
            }
        }
    }
}