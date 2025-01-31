using Atomic.Elements;

namespace Game.Gameplay
{
    public class WeaponFireAction : IAction
    {
        private readonly IWeaponEntity _entity;
        private readonly IGameContext _context;

        public WeaponFireAction(IWeaponEntity entity, IGameContext context)
        {
            _entity = entity;
            _context = context;
        }

        public void Invoke()
        {
            if (_entity.GetFireCondition().Invoke())
            {
                _entity.FireBullet(_context);
                _entity.GetAmmo().SpendOne();
                _entity.GetFireEvent().Invoke();
            }
        }
    }
}