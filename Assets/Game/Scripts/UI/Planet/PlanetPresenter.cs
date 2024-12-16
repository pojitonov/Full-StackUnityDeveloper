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
            _planet.OnIncomeTimeChanged += OnIncomeTimeChanged;
            _planet.OnIncomeReady += OnIncomeReady;
            _planet.OnUnlocked += OnUnlocked;

            UpdateView();
        }

        public void Dispose()
        {
            _view.OnPlanetClick -= OnPlanetClick;
            _view.OnPlanetHoldClick -= OnPlanetHoldClick;
            _planet.OnIncomeTimeChanged -= OnIncomeTimeChanged;
            _planet.OnIncomeReady -= OnIncomeReady;
            _planet.OnUnlocked -= OnUnlocked;
        }

        private void OnUnlocked()
        {
            _view.ShowLock(false);
        }

        private void OnIncomeReady(bool isReady)
        {
            _view.ShowCoin(isReady);
        }

        private void OnPlanetClick()
        {
            if (_money.IsEnough(_planet.Price) && !_planet.IsUnlocked)
            {
                _planet.Unlock();
                UpdateView();
            }

            if (_planet.IsIncomeReady)
            {
                _planet.GatherIncome();
            }
        }

        private void OnPlanetHoldClick()
        {
            _shower.Show(_planet);
        }

        private void UpdateView()
        {
            _view.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _view.SetPrice(_planet.Price.ToString());
            _view.SetTime(_planet.Price.ToString());
            _view.ShowCoin(_planet.GatherIncome());
            _view.ShowTimer(_planet.GatherIncome());
            _view.ShowPrice(!_planet.IsUnlocked);
        }

        private void OnIncomeTimeChanged(float time)
        {
            _view.StartTimer(time, _planet.IncomeProgress);
        }
    }
}