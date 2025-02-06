using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public class CharacterFireAction : IAction
    {
        private readonly IEntity _entity;

        public CharacterFireAction(IEntity entity)
        {
            _entity = entity;
        }

        public void Invoke()
        {
            if (_entity.GetAttackCondition().Invoke())
            {
                _entity.GetWeapon().GetAttackAction().Invoke();
                _entity.GetAttackEvent().Invoke();
            }
        }
    }
}