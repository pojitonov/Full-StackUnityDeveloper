using Atomic.Entities;

namespace Game.Gameplay
{
    public class AttackBehaviour : IEntityInit, IEntityDispose
    {
        private IGameContext _gameContext;

        public void Init(in IEntity entity)
        {

        }

        public void Dispose(in IEntity entity)
        {
        }
    }
}