using Game.Scripts.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Components
{
    public class DeathHandler : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private Cooldown cooldown;

        private void OnEnable()
        {
            _healthComponent.OnDied += Destroy;
        }

        private void OnDisable()
        {
            _healthComponent.OnDied -= Destroy;
        }

        private void Update()
        {
            cooldown.Tick(Time.deltaTime);

            if (cooldown.IsTimeUp() && !_healthComponent.IsAlive)
            {
                Destroy(gameObject);
            }
        }

        private void Destroy()
        {
            cooldown.Reset();
        }
    }
}