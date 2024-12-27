using Game.UI.Signals;
using Zenject;

namespace Game.UI.Planet
{
    public sealed class PlanetInstaller : Installer<PlanetView[], PlanetInstaller>
    {
        [Inject]
        private PlanetView[] planetViews;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<PlanetInitializer>()
                .AsSingle()
                .WithArguments(planetViews);
            
            Container.DeclareSignal<CoinGatheredSignal>();
            
            Container.BindInterfacesAndSelfTo<CoinAnimationController>()
                .AsSingle();
        }
    }
}