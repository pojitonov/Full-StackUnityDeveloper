using System;
using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class StatsSystemInstaller : IContextInstaller<IGameContext>
    {
        [SerializeField] private List<SceneEntity> _enemies;
        
        public void Install(IGameContext context)
        {
            context.AddKills(new ReactiveInt());
            context.AddController(new KillsCountController(_enemies));
        }
    }
}