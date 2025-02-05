using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class BodyFallDisableBehaviour : IEntityInit, IEntityDispose
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
            _entity.DelBehaviour<AttackAnimBehaviour>();
            _entity.GetGameObject().GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}