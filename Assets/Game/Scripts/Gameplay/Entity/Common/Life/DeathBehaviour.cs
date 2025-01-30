using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public class DeathBehaviour : IEntityInit, IEntityDispose
    {
        private IReactiveValue<int> _health;
        private IEntity _entity;

        public void Init(in IEntity entity)
        {
            _entity = entity;
            _health = entity.GetHealth();
            _health.Subscribe(OnHealthChanged);
        }

        public void Dispose(in IEntity entity)
        {
            _health.Unsubscribe(OnHealthChanged);
        }

        private void OnHealthChanged(int health)
        {
            if (health > 0) return;
            _entity.GetDeathEvent().Invoke();
        }
    }
}