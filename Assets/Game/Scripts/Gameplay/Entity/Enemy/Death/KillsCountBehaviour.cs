using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;

namespace Game.Scripts.Gameplay.Entity.Enemy
{
    public class KillsCountBehaviour : IEntityInit, IEntityDispose
    {
        private IGameContext _gameContext;
        private IReactive _deathEvent;

        public void Init(in IEntity entity)
        {
            _gameContext = GameContext.Instance;
            _deathEvent = entity.GetDeathEvent();
            _deathEvent.Subscribe(OnDeathHappens);
        }

        public void Dispose(in IEntity entity)
        {
            _deathEvent.Unsubscribe(OnDeathHappens);
        }

        private void OnDeathHappens()
        {
            _gameContext.GetKills().Value++;
        }
    }
}