using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public class EnemyAttackAction : IAction
    {
        private readonly IEntity _entity;

        public EnemyAttackAction(IEntity entity)
        {
            _entity = entity;
        }

        public void Invoke()
        {
            if (_entity.GetAttackCondition().Invoke())
            {
                _entity.GetWeapon().GetAttackAction().Invoke();
            }
        }
    }
}