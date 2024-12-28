using Modules.UI;
using Zenject;

namespace Game.UI.Planet
{
    public sealed class CoinInstaller : Installer<CoinInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ParticleAnimator>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
        }
    }
}