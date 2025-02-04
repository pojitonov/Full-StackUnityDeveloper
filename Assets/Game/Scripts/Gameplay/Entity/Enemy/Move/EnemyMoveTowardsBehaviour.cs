using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class EnemyMoveTowardsBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private IGameContext _gameContext;

        public void Init(in IEntity entity)
        {
            _gameContext = GameContext.Instance;
        }

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            var currentPosition = entity.GetTransform().position;
            var targetPosition = _gameContext.GetCharacter().GetTransform().position;
            var direction = (targetPosition - currentPosition).normalized;
            
            entity.GetMoveDirection().Value = direction;
            entity.MoveTowardsPosition(targetPosition, deltaTime);
        }
    }
}