using Game.UI.Money;
using Game.UI.Planet;
using Game.UI.Popup;
using Game.UI.Signals;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField]
        private PlanetView[] planetViews;
        
        public override void InstallBindings()
        {
            Container
                .BindFactory<PlanetView, IPlanet, PlanetPresenter, PlanetPresenterFactory>()
                .AsCached();
   
            CoinInstaller.Install(Container);
            MoneyInstaller.Install(Container);
            PlanetInstaller.Install(Container,  planetViews);
            PlanetPopupInstaller.Install(Container);
            SignalsInstaller.Install(Container);
        }
    }   
}