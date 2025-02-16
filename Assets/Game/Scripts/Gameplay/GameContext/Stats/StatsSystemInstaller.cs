using System;
using Atomic.Contexts;
using Atomic.Elements;
using Modules.Common;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class StatsSystemInstaller : IContextInstaller<IGameContext>
    {
        public void Install(IGameContext context)
        {
            context.AddKills(new ReactiveInt());
            // context.AddController<KillsCountController>();
        }
    }
}