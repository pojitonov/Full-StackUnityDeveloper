using Game.UI.Planet;
using Zenject;

namespace Game.UI
{
    public sealed class PlanetInstaller : Installer<PlanetView, PlanetInstaller>
    {
        [Inject]
        private PlanetView _planetView;

        public override void InstallBindings()
        {
            Container
                .Bind<PlanetView>()
                .FromComponentInHierarchy()
                .AsTransient()
                .NonLazy();

            Container
                .BindInterfacesTo<PlanetPresenter>()
                .AsTransient()
                .WithArguments(_planetView)
                .NonLazy();
        }
    }
}