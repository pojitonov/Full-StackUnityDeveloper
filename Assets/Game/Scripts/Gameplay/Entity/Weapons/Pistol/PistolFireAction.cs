using Atomic.Elements;

namespace Game.Gameplay
{
    public class PistolFireAction : IAction
    {
        private readonly IWeaponEntity _entity;
        private readonly IGameContext _context;

        public PistolFireAction(IWeaponEntity entity, IGameContext context)
        {
            _entity = entity;
            _context = context;
        }

        public void Invoke()
        {
            if (_entity.GetFireCondition().Invoke())
            {
                _entity.FireBullet(_context);
                _entity.GetFireEvent().Invoke();
            }
        }
    }
}