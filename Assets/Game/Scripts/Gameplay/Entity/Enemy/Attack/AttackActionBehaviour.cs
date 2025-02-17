using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class AttackActionBehaviour : IEntityInit, IEntityDispose
    {
        private readonly string _eventName;

        public AttackActionBehaviour(string eventName)
        {
            _eventName = eventName;
        }

        public void Init(in IEntity entity)
        {
            entity.GetAnimationEventReceiver().Subscribe(_eventName, entity.GetWeapon().GetAttackAction().Invoke);
        }

        public void Dispose(in IEntity entity)
        {
            entity.GetAnimationEventReceiver().Unsubscribe(_eventName, entity.GetWeapon().GetAttackAction().Invoke);
        }
    }
}