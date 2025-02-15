using Atomic.Elements;
using Atomic.Entities;

//TODO: Make a separate controller that will count dead zombies (9:00)
// Do not attach this to zombies itself but have separate responsible for this
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