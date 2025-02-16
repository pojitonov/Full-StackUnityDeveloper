using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public class AttackAction : IAction
    {
        private readonly IEntity _entity;
        private readonly IEntity _target;
        private readonly float _stoppingDistance;

        public AttackAction(IEntity entity, IEntity target, float stoppingDistance)
        {
            _entity = entity;
            _target = target;
            _stoppingDistance = stoppingDistance;
        }

        public void Invoke()
        {
            if (_target == null)
                return;

            if (_entity.TryGetAttackCondition(out var condition) && !condition.Invoke())
                return;

            float distance = _entity.GetDistance(_target);

            if (distance < _stoppingDistance)
                _entity.GetAttackEvent().Invoke();
        }
    }
}