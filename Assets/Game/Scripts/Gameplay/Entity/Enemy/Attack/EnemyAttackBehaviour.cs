using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public class EnemyAttackBehaviour : IEntityInit, IEntityDispose, IEntityUpdate
    {
        private Cooldown _cooldown;
        private readonly string _eventName;
        private readonly float _stoppingDistance;
        private IEntity _entity;
        private bool _isAttacking;

        public EnemyAttackBehaviour(string eventName, float stoppingDistance)
        {
            _eventName = eventName;
            _stoppingDistance = stoppingDistance;
        }

        public void Init(in IEntity entity)
        {
            _entity = entity;
            _cooldown = new Cooldown(entity.GetAttackDelay().Value);
            _cooldown.Reset();

            entity.GetAnimationEventReceiver().Subscribe(_eventName, OnAttackAnimationEvent);
        }

        public void Dispose(in IEntity entity)
        {
            entity.GetAnimationEventReceiver().Unsubscribe(_eventName, OnAttackAnimationEvent);
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            _cooldown.Tick(deltaTime);
            
            if (_isAttacking)
                return;

            if (entity.CanAttack(_stoppingDistance, _cooldown))
            {
                entity.GetAttackAction().Invoke();
                _isAttacking = true;
            }
        }

        private void OnAttackAnimationEvent()
        {
            _cooldown.Reset();
            _entity.GetWeapon().GetAttackAction().Invoke();
            _isAttacking = false;
        }
    }
}