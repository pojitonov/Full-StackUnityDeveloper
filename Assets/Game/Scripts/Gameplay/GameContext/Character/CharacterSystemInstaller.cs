using System;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class CharacterSystemInstaller : IContextInstaller<IGameContext>
    {
        [SerializeField] private SceneEntity _character;
        
        public void Install(IGameContext context)
        {
            context.AddTarget(new ReactiveVariable<IEntity>(_character));
        }
    }
}