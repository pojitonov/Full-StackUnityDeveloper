using Atomic.Contexts;
using UnityEngine;

namespace Game.Gameplay
{
    public class GameContextInstaller : SceneContextInstaller<IGameContext>
    {
        [SerializeField] private BulletSystemInstaller _bulletSystemInstaller;

        protected override void Install(IGameContext context)
        {
            _bulletSystemInstaller.Install(context);
        }
    }
}