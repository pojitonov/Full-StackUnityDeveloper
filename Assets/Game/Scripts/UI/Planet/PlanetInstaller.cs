using Game.UI.Planet;
using Modules.Planets;
using Modules.UI;
using Zenject;

namespace Game.UI
{
    public sealed class PlanetInstaller : Installer<PlanetView[], PlanetInstaller>
    {
        [Inject]
        private PlanetView[] planetViews;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<PlanetPresenterInitializer>()
                .AsSingle()
                .WithArguments(planetViews);
            
            // Container
            //     .BindInterfacesTo<PlanetAnimationController>()
            //     .AsCached()
            //     .NonLazy();
            //
            // Container
            //     .Bind<PlanetAnimation>()
            //     .FromComponentInHierarchy()
            //     .AsCached();
        }
    }
}