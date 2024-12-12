using Game.UI.Planet;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField]
        private MoneyView moneyView;
        
        [SerializeField]
        private PlanetView planetView;
        
        public override void InstallBindings()
        {
            MoneyInstaller.Install(Container, moneyView);
            PlanetInstaller.Install(Container, planetView);
            PlanetPopupInstaller.Install(Container);
        }
    }
}