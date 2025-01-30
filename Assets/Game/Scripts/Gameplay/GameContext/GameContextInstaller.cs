using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class GameContextInstaller : SceneContextInstaller<IGameContext>
    {
        [SerializeField] private BulletSystemInstaller _bulletSystemInstaller;
        [SerializeField] private CharacterSystemInstaller _characterSystemInstaller;

        protected override void Install(IGameContext context)
        {
            context.SetKills(new ReactiveInt());
            
            _bulletSystemInstaller.Install(context);
            _characterSystemInstaller.Install(context);
        }
    }
}