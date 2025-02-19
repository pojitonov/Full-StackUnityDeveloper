using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    //TODO: Не смог получить Зомби из EntityWorld, поэтому использовал список
    //Если раскоментировать Лог получаю NullReference (компонент EntityWorld висит на GameContext)
    public class KillsCountController : IContextInit<GameContext>, IContextDispose<GameContext>
    {
        private IEntityWorld _entityWorld;
        private IGameContext _gameContext;
        private readonly List<IReactive<DamageArgs>> _deathEvents = new();
        private readonly List<SceneEntity> _enemies;

        public KillsCountController(List<SceneEntity> enemies)
        {
            _enemies = enemies;
        }

        public void Init(GameContext context)
        {
            _entityWorld = context.GetEntityWorld();
            // Debug.Log(_entityWorld.EntityCount);

            _gameContext = context;
            Subscribe();
        }

        private void Subscribe()
        {
            foreach (IEntity enemy in _enemies)
            {
                var deathEvent = enemy.GetDeathEvent();
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

// Log
// NullReferenceException: Object reference not set to an instance of an object
// Game.Gameplay.KillsCountController.Init (Game.Gameplay.GameContext context) (at Assets/Game/Scripts/Gameplay/Entity/Character/Controllers/KillsCountController.cs:26)
// Atomic.Contexts.IContextInit`1[T].Atomic.Contexts.IContextInit.Init (Atomic.Contexts.IContext context) (at Assets/Plugins/Atomic/Context/Scripts/Behaviours/IContextInit.cs:11)
// Atomic.Contexts.Context.Init () (at Assets/Plugins/Atomic/Context/Scripts/Contexts/Plain/Context_Lifecycle.cs:42)
// Atomic.Contexts.SceneContext.Init () (at Assets/Plugins/Atomic/Context/Scripts/Contexts/Mono/SceneContext_Lifecycle.cs:53)
// Atomic.Contexts.SceneContextRunner.Start () (at Assets/Plugins/Atomic/Context/Scripts/Contexts/Mono/SceneContextRunner.cs:57)