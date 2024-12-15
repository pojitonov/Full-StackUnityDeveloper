using System;
using Game.UI.Planets;
using Modules.Planets;
using UnityEngine;
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
            _view.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _view.SetPrice(_planet.Price.ToString());
            _view.SetTime(_planet.Price.ToString());
            _view.ShowUnlockedState(_planet.IsUnlocked);
            _view.ShowCoin(_planet.GatherIncome());
            _view.OnPlanetClick += OnPlanetClick;
            _view.OnPlanetHoldClick += OnPlanetHoldClick;
        }

        public void Dispose()
        {
            _view.OnPlanetClick -= OnPlanetClick;
            _view.OnPlanetHoldClick -= OnPlanetHoldClick;
        }

        private void OnPlanetClick()
        {
            if (_money.IsEnough(_planet.Price) && !_planet.IsUnlocked)
            {
                _planet.Unlock();
                _view.SetPrice(_planet.Price.ToString());
                _view.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
                _view.ShowUnlockedState(_planet.IsUnlocked);
            }
        }

        private void OnPlanetHoldClick()
        {
            _shower.Show(_planet);
        }
    }
}