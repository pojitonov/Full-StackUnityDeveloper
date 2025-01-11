using Zenject;

namespace Game.UI.Popup
{
    public sealed class PlanetPopupInstaller : Installer<PlanetPopupInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlanetPopupView>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<PlanetPopupPresenter>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<PlanetPopupController>()
                .AsSingle()
                .NonLazy();
        }
    }
}