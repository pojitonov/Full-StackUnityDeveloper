using System;
using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Modules.Common;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class StatsSystemInstaller : IContextInstaller<IGameContext>
    {
        [SerializeField] private List<SceneEntity> entities;
        
        public void Install(IGameContext context)
        {
            context.AddKills(new ReactiveInt());
            context.AddController(new KillsCountController(entities));
        }
    }
}