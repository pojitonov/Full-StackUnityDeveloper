using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class EnemyMoveTowardsBehaviour : IEntityInit, IEntityUpdate
    {
        private IGameContext _gameContext;

        public void Init(in IEntity entity)
        {
            _gameContext = GameContext.Instance;
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            var targetPosition = _gameContext.GetCharacter().GetTransform().position;
            
            entity.MoveTowardsPosition(targetPosition, deltaTime);
        }
    }
}