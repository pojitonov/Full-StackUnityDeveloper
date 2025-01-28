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
            if (_entity.GetFireCondition().Invoke())
            {
                _entity.GetWeapon().GetFireAction().Invoke();
                _entity.GetFireEvent().Invoke();
            }
        }
    }
}