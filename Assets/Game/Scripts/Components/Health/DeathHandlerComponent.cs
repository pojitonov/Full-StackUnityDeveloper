using Game.Scripts.Core;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class DeathHandlerComponent : MonoBehaviour
    {
        [SerializeField] private Cooldown cooldown;

        private bool _isDead;

        private void Update()
        {
            if (_isDead)
            {
                cooldown.Tick(Time.deltaTime);

                if (cooldown.IsTimeUp())
                {
                    Destroy(gameObject);
                }
            }
        }

        public void TriggerDeath()
        {
            _isDead = true;
            cooldown.Reset();
        }
    }
}