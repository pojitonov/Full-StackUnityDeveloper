using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public class KillsCountController : IContextInit<GameContext>, IContextDispose<GameContext>
    {
        private IGameContext _gameContext;
        private readonly List<IReactive<DamageArgs>> _deathEvents = new();
        private readonly List<SceneEntity> _entities;

        public KillsCountController(List<SceneEntity> entities)
        {
            _entities = entities;
        }
        
        public void Init(GameContext context)
        {
            _gameContext = context;

            foreach (IEntity entity in _entities)
            {
                var deathEvent = entity.GetDeathEvent();
                deathEvent.Subscribe(OnDeathHappens);
                _deathEvents.Add(deathEvent);
            }
        }

        public void Dispose(GameContext context)
        {
            foreach (var deathEvent in _deathEvents)
            {
                deathEvent.Unsubscribe(OnDeathHappens);
            }

            _deathEvents.Clear();
        }

        private void OnDeathHappens(DamageArgs _)
        {
            _gameContext.GetKills().Value++;
        }
    }
}