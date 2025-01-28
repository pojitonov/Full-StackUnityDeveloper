using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public class PistolFireAction : IAction
    {
        private readonly IWeaponEntity _entity;

        public PistolFireAction(IWeaponEntity entity)
        {
            _entity = entity;
        }

        public void Invoke()
        {
            if (_entity.GetFireCondition().Invoke())
            {
                _entity.FireBullet();
                _entity.GetFireEvent().Invoke();
            }
        }
    }
}