using Atomic.Entities;
using Modules.Gameplay;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Game.Gameplay
{
    public class EnemyAttackBehaviour : IEntityInit, IEntityDispose, IEntityUpdate
    {
        private Cooldown _cooldown;
        private readonly string _eventName;
        private float _attackDelay;
        private readonly float _stoppingDistance = 1f;

        public EnemyAttackBehaviour(string eventName)
        {
            _eventName = eventName;
        }

        public void Init(in IEntity entity)
        {
            entity.GetAnimationEventReceiver().Subscribe(_eventName, entity.GetAttackAction().Invoke);

            _attackDelay = entity.GetAttackDelay().Value;
            _cooldown = new Cooldown(_attackDelay);
            _cooldown.Reset();
        }

        public void Dispose(in IEntity entity)
        {
            entity.GetAnimationEventReceiver().Unsubscribe(_eventName, entity.GetAttackAction().Invoke);
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            if (entity == null)
                return;

            var target = entity.GetTarget();
            var distance = entity.GetDistance(target);
            
            if (distance < _stoppingDistance)
            {
                _cooldown.Tick(deltaTime);

                if (_cooldown.IsExpired())
                {
                    entity.GetAttackEvent().Invoke();
                    _cooldown.Reset();
                }
            }
        }
    }
}