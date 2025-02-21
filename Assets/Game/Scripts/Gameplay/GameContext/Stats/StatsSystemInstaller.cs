using System;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class StatsSystemInstaller : IContextInstaller<IGameContext>
    {
        [SerializeField] private SceneEntityWorld _entityWorld;
        
        public void Install(IGameContext context)
        {
            context.AddEntityWorld(_entityWorld);
            context.AddKills(new ReactiveInt());
            context.AddController(new KillsCountController());
        }
    }
}