using Game.UI.Planet;
using Modules.Planets;
using Zenject;

namespace Game.UI
{
    public sealed class PlanetInstaller : Installer<PlanetCatalog, PlanetView[], PlanetInstaller>
    {
        [Inject]
        private PlanetCatalog _catalog;

        [Inject]
        private PlanetView[] _planetViews;
        
        [Inject]
        private PlanetPresenterFactory _presenterFactory;

        public override void InstallBindings()
        {
            foreach (PlanetConfig config in _catalog)
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