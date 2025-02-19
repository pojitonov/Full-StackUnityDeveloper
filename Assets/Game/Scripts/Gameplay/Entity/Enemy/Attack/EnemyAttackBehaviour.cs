using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public class EnemyAttackBehaviour : IEntityInit, IEntityDispose, IEntityUpdate
    {
        private Cooldown _cooldown;
        private readonly string _eventName;
        private float _attackDelay;
        private readonly float _stoppingDistance;
        private IAction _weaponAttachAction;

        public EnemyAttackBehaviour(string eventName, float stoppingDistance)
        {
            _eventName = eventName;
            _stoppingDistance = stoppingDistance;
        }

        public void Init(in IEntity entity)
        {
            _weaponAttachAction = entity.GetWeapon().GetAttackAction();
            _attackDelay = entity.GetAttackDelay().Value;
            _cooldown = new Cooldown(_attackDelay);
            _cooldown.Reset();

            entity.GetAnimationEventReceiver().Subscribe(_eventName, _weaponAttachAction.Invoke);
        }

        public void Dispose(in IEntity entity)
        {
            entity.GetAnimationEventReceiver().Unsubscribe(_eventName, _weaponAttachAction.Invoke);
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            EnemyAttackUseCase.Attack(entity, deltaTime, _stoppingDistance, _cooldown);
        }
    }
}