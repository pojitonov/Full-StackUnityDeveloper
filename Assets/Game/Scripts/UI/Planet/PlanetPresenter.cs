using System;
using Game.UI.Planets;
using Modules.Planets;
using Zenject;

namespace Game.UI.Planet
{
    public class PlanetPresenter : IInitializable, IDisposable
    {
        private readonly IMoneyAdapter _money;
        private readonly PlanetView _view;
        private readonly IPlanet _planet;
        private readonly PlanetPopupShower _shower;

        public PlanetPresenter(IMoneyAdapter money, PlanetView view, IPlanet planet, PlanetPopupShower shower)
        {
            _view = view;
            _money = money;
            _planet = planet;
            _shower = shower;
        }

        public void Initialize()
        {
            _view.OnPlanetClick += OnPlanetClick;
            _view.OnPlanetHoldClick += OnPlanetHoldClick;
            _planet.OnIncomeReady += OnIncomeReady;
            _planet.OnUnlocked += OnUnlocked;
            _planet.OnUpgraded += OnUpgraded;
            _planet.OnGathered += OnGathered;

            UpdateView();
        }

        public void Dispose()
        {
            _view.OnPlanetClick -= OnPlanetClick;
            _view.OnPlanetHoldClick -= OnPlanetHoldClick;
            _planet.OnIncomeReady -= OnIncomeReady;
            _planet.OnUnlocked -= OnUnlocked;
            _planet.OnUpgraded -= OnUpgraded;
            _planet.OnGathered -= OnGathered;
        }

        private void OnUnlocked()
        {
            UpdateView();
        }

        private void OnUpgraded(int _)
        {
            UpdateView();
        }
        
        private void OnGathered(int _)
        {
            UpdateView();
        }

        private void OnPlanetClick()
        {
            if (_money.IsEnough(_planet.Price) && !_planet.IsUnlocked)
                _planet.Unlock();
            if (_planet.IsIncomeReady) 
                _planet.GatherIncome();
        }

        private void OnPlanetHoldClick()
        {
            _shower.Show(_planet);
        }

        private void OnIncomeReady(bool isReady)
        {
            _view.ShowCoin(isReady);
            _view.ShowTimer(!isReady);
        }

        private void UpdateView()
        {
            _view.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _view.ShowTimer(_planet.IsUnlocked && !_planet.IsIncomeReady);
            _view.SetPrice(_planet.Price.ToString());
            _view.SetTime(_planet.Price.ToString());
            _view.ShowCoin(_planet.IsIncomeReady);
            _view.ShowLock(!_planet.IsUnlocked);
            _view.ShowPrice(!_planet.IsUnlocked);
        }
    }
}