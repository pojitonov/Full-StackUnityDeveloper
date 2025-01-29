using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public class BulletSpawnAction : IAction
    {
        private readonly IEntity _entity;
        private readonly IGameContext _context;

        public BulletSpawnAction(IEntity entity, IGameContext context)
        {
            _entity = entity;
            _context = context;
        }

        public void Invoke()
        {
            SpawnBulletUseCase.UnspawnBullet(_entity, _context);
        }
    }
}