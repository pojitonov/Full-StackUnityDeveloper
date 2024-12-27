using Game.UI.Planet;
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
                .BindInterfacesTo<PlanetInitializer>()
                .AsSingle()
                .WithArguments(planetViews);
        }
    }
}