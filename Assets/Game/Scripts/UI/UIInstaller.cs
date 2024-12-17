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
        
        [SerializeField]
        private GameObject _coinEndPosition;
        
        public override void InstallBindings()
        {
            Container
                .BindFactory<PlanetView, IPlanet, PlanetPresenter, PlanetPresenterFactory>()
                .AsCached();

            Container
                .BindInterfacesTo<PlanetPresenterInitializer>()
                .AsSingle()
                .WithArguments(planetViews);
            
            MoneyInstaller.Install(Container, moneyView);
            PlanetInstaller.Install(Container, catalog);
            PlanetPopupInstaller.Install(Container);
            ModulesInstaller.Install(Container);
            
        }
    }   
}