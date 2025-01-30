using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public class BodyDisableBehaviour : IEntityInit, IEntityDispose
    {
        private IEntity _entity;
        private IReactive _deathEvent;

        public void Init(in IEntity entity)
        {
            _entity = entity;
            _deathEvent = entity.GetDeathEvent();
            _deathEvent.Subscribe(OnDeathHappens);
        }

        public void Dispose(in IEntity entity)
        {
            _deathEvent.Unsubscribe(OnDeathHappens);
        }

        private void OnDeathHappens()
        {
            _entity.DelBehaviour<TakeDamageAnimBehaviour>();
            _entity.DelBehaviour<EnemyLookAtBehaviour>();
        }
    }
}