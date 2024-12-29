using Zenject;

namespace Game.UI.Signals
{
    public sealed class SignalsInstaller : Installer<SignalsInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<CoinGatheredSignal>();
            Container.DeclareSignal<OpenPlanetPopupSignal>();
        }
    }
}