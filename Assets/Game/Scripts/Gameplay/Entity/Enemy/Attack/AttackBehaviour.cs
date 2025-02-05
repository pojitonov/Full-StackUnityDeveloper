using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public class AttackBehaviour : IEntityInit, IEntityUpdate
    {
        private IEntity _target;
        private readonly Cooldown _cooldown;
        private readonly float _attackRange;

        public AttackBehaviour(float attackRange, float attackInterval)
        {
            _attackRange = attackRange ;
            _cooldown = new Cooldown(attackInterval);
        }

        public void Init(in IEntity entity)
        {
            _target = entity.GetTarget();
            _cooldown.Reset();
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            entity.Attack(_target, _cooldown, _attackRange, deltaTime);
        }
    }
}