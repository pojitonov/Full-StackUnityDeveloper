using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public class KillsCountController : IContextInit<GameContext>, IContextDispose<GameContext>
    {
        private IEntityWorld _entityWorld;
        private IGameContext _gameContext;
        private readonly List<IReactive<DamageArgs>> _deathEvents = new();

        public void Init(GameContext context)
        {
            _gameContext = context;
            _entityWorld = context.GetEntityWorld();

            foreach (IEntity entity in _entityWorld.GetEntitiesWithTag(EntityAPI.Enemy))
            {
                Debug.Log(entity.Name);
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