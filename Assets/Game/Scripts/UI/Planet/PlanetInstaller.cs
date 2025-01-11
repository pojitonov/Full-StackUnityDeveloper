using Modules.Planets;
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
                .BindFactory<PlanetView, IPlanet, PlanetPresenter, PlanetPresenterFactory>()
                .AsCached();
              
            Container
                .BindInterfacesTo<PlanetInitializer>()
                .AsSingle()
                .WithArguments(planetViews);
        }
    }
}