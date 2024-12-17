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
        private PlanetCatalog catalog;
        
        [SerializeField]
        private PlanetView[] planetViews;

        [SerializeField]
        private GameObject coinEndPosition;
        
        public override void InstallBindings()
        {
            Container
                .BindFactory<PlanetView, IPlanet, PlanetPresenter, PlanetPresenterFactory>()
                .AsCached();
            
            MoneyInstaller.Install(Container, moneyView);
            PlanetInstaller.Install(Container, catalog, planetViews);
            PlanetPopupInstaller.Install(Container);
            ModulesInstaller.Install(Container, coinEndPosition);
            
        }
    }   
}