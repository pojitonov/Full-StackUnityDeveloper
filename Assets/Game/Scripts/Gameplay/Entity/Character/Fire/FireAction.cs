using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public class FireAction : IAction
    {
        private IEntity _entity;

        public FireAction(IEntity entity)
        {
            _entity = entity;
        }

        public void Invoke()
        {
            if (_entity.GetFireCondition().Invoke())
            {
                _entity.GetWeapon().FireBullet();
                _entity.GetFireEvent().Invoke();
            }
        }
    }
}