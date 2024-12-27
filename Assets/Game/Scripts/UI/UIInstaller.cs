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
        
        public override void InstallBindings()
        {
            Container
                .BindFactory<PlanetView, IPlanet, PlanetPresenter, PlanetPresenterFactory>()
                .AsCached();
            
            MoneyInstaller.Install(Container, moneyView);
            PlanetInstaller.Install(Container,  planetViews);
            PlanetPopupInstaller.Install(Container);
        }
    }   
}