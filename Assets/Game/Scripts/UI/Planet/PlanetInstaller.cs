using Game.UI.Planet;
using Modules.Planets;
using Zenject;

namespace Game.UI
{
    public sealed class PlanetInstaller : Installer<PlanetCatalog, PlanetView[], PlanetInstaller>
    {
        [Inject]
        private PlanetCatalog catalog;

        [Inject]
        private PlanetPresenterFactory presenterFactory;

        [Inject]
        private PlanetView[] planetViews;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<PlanetPresenterInitializer>()
                .AsSingle()
                .WithArguments(planetViews);

            foreach (PlanetConfig config in catalog)
            {
                Container
                    .Bind<IPlanet>()
                    .To<Modules.Planets.Planet>()
                    .AsCached()
                    .WithArguments(config)
                    .WhenInjectedInto<PlanetPresenterFactory>();
            }
        }
    }
}