using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class EnemyLookAtBehaviour : IEntityFixedUpdate, IEntityInit
    {
        private IGameContext _gameContext;
        
        public void Init(in IEntity entity)
        {
            _gameContext = GameContext.Instance;
        }

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            IEntity target = _gameContext.GetTarget().Value;
            
            if (target == null)
                return;
            
            Vector3 direction = entity.GetLookAtDirection(target);
            entity.RotateTowards(direction, deltaTime);
        }
    }
}