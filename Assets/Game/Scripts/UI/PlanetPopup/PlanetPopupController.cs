using System;
using Game.UI.Signals;
using Zenject;

namespace Game.UI.Popup
{
    public class PlanetPopupController : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly PlanetPopupPresenter _popupPresenter;
        private readonly PlanetPopupView _popupView;

        public PlanetPopupController(SignalBus signalBus, PlanetPopupPresenter popupPresenter, PlanetPopupView popupView)
        {
            _popupPresenter = popupPresenter;
            _signalBus = signalBus;
            _popupView = popupView;
        }
 
        public void Initialize()
        {
            _signalBus.Subscribe<OpenPlanetPopupSignal>(ConfigurePopup);
        } 

        public void Dispose()
        {
            _signalBus.Unsubscribe<OpenPlanetPopupSignal>(ConfigurePopup);
        }

        private void ConfigurePopup(OpenPlanetPopupSignal signal)
        {
            _popupPresenter.SetPlanet(signal.Planet);
            _popupView.Show();
        }
    }
}