using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public class DeathBehaviour : IEntityInit, IEntityDispose
    {
        private Health _health;
        private IEntity _entity;

        public void Init(in IEntity entity)
        {
            _entity = entity;
            _health = entity.GetHealth();
            _health.OnHealthChanged += OnValueChanged;
        }

        public void Dispose(in IEntity entity)
        {
            _health.OnHealthChanged -= OnValueChanged;
        }

        private void OnValueChanged(int health)
        {
            if (health > 0) return;
            _entity.GetDeathEvent().Invoke();
        }
    }
}