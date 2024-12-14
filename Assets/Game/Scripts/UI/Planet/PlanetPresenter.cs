using System;
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
        // private readonly PlanetPopupShower _shower;

        public PlanetPresenter(IMoneyAdapter money, PlanetView view, IPlanet planet)
        {
            _view = view;
            _money = money;
            _planet = planet;
            // _shower = shower;
        }

        public void Initialize()
        {
            // Debug.Log($"Initializing presenter for planet {_planet}");

            _view.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _view.SetPrice(_planet.Price.ToString());
            _view.SetTimer(_planet.Price.ToString());
            _view.SetState(_planet.IsUnlocked);
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
                _planet.Unlock();
        }
        private void OnPlanetHoldClick()
        {
            // if (_planet.IsUnlocked)
            //     _shower.Show(_planet);
        }
    }
}