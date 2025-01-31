using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public class InteractBehaviour : IEntityInit, IEntityDispose
    {
        private TriggerEventReceiver _trigger;
        private IEntity _entity;

        public void Init(in IEntity entity)
        {
            _entity = entity;
            _trigger = entity.GetTrigger();
            _trigger.OnEntered += OnTriggerEntered;
        }

        public void Dispose(in IEntity entity)
        {
            _trigger.OnEntered -= OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            if (collider.TryGetComponent(out IEntity other))
            {
                InteractUseCase.Interact(_entity, other);
            }
        }
    }
}