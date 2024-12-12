using Game.UI.Planets;
using Zenject;

public sealed class PlanetPopupInstaller : Installer<PlanetPopupInstaller>
{
    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<PlanetPopupPresenter>()
            .AsSingle()
            .NonLazy();
    }
}