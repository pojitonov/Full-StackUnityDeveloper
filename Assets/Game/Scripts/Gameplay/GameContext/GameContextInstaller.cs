using Atomic.Contexts;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public class GameContextInstaller : SceneContextInstaller<IGameContext>
    {
        [SerializeField] private InputSystemInstaller _inputSystemInstaller;
        [SerializeField] private CharacterSystemInstaller _characterSystemInstaller;
        [SerializeField] private BulletSystemInstaller _bulletSystemInstaller;

        protected override void Install(IGameContext context)
        {
            context.AddKills(new ReactiveInt());
            
            _inputSystemInstaller.Install(context);
            _characterSystemInstaller.Install(context);
            _bulletSystemInstaller.Install(context);
        }
    }
} 