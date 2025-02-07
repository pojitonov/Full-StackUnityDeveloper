using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public class KillsCountBehaviour : IEntityInit, IEntityDispose
    {
        private IGameContext _gameContext;
        private IReactive<DamageArgs> _deathEvent;

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

        private void OnDeathHappens(DamageArgs _)
        {
            _gameContext.GetKills().Value++;
        }
    }
}