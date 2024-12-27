using Zenject;

namespace Game.UI.Popup
{
    public sealed class PlanetPopupInstaller : Installer<PlanetPopupInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlanetPopupPresenter>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlanetPopupShower>()
                .AsSingle();

            Container
                .Bind<PlanetPopupView>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}