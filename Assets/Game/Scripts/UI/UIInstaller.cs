using Game.UI.Planet;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField]
        private MoneyView moneyView;

        [SerializeField]
        private PlanetView[] planetViews;

        [SerializeField]
        private PlanetCatalog catalog;

        public override void InstallBindings()
        {
            Container
                .BindFactory<PlanetView, IPlanet, PlanetPresenter, PlanetPresenterFactory>()
                .AsCached();
            
            MoneyInstaller.Install(Container, moneyView);
            PlanetInstaller.Install(Container, catalog, planetViews);
            // PlanetPopupInstaller.Install(Container);
            
            Container
                .BindInterfacesTo<PlanetPresenterInitializer>()
                .AsSingle()
                .WithArguments(planetViews);
        }
    }   
}