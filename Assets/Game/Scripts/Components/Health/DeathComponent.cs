using UnityEngine;

namespace Game
{
    // Идея этого компонента, иметь возможность реализовать локигу при смерти
    // Например задержка по Cooldown чтобы успела отыграть анимация и звуки перед отключением
    
    public class DeathComponent : MonoBehaviour
    {
        [SerializeField] private Cooldown cooldown;

        private bool _isDead;

        private void Update()
        {
            if (_isDead)
            {
                cooldown.Tick(Time.deltaTime);

                if (cooldown.IsTimeUp())
                    gameObject.SetActive(false);
            }
        }

        public void TriggerDeath()
        {
            _isDead = true;
            cooldown.Reset();
        }
    }
}