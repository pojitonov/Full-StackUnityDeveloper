using Zenject;

namespace Game.UI.PlanetPopup
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