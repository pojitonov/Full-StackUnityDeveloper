using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class DeathBehaviour : IEntityInit, IEntityDispose
    {
        private IReactiveValue<int> _health;
        private GameObject _gameObject;

        public void Init(in IEntity entity)
        {
            _health = entity.GetHealth();
            _health.Subscribe(OnHealthChanged);
            _gameObject = entity.GetGameObject();
        }

        public void Dispose(in IEntity entity)
        {
            _health.Unsubscribe(OnHealthChanged);
        }

        private void OnHealthChanged(int health)
        {
            if (health <= 0)
                _gameObject.SetActive(false);
        }
    }
}