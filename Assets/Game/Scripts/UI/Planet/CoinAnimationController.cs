using System;
using Game.UI.Planet;
using Modules.Planets;
using Modules.UI;
using Zenject;

namespace Game.UI
{
    public sealed class CoinAnimationController : IInitializable, IDisposable
    {
        private readonly IPlanet _planet;
        private readonly PlanetView _view;
        private readonly CoinAnimation _animation;

        public CoinAnimationController(IPlanet planet, PlanetView view, CoinAnimation animation)
        {
            _planet = planet;
            _view = view;
            _animation = animation;
        }

        public void Initialize()
        {
            _view.OnPlanetClick += OnPlanetClick;
        }

        public void Dispose()
        {
            _view.OnPlanetClick -= OnPlanetClick;
        }

        private void OnPlanetClick()
        {
            if (_planet.IsIncomeReady)
            {
                _animation.StartAnimation();
            }
        }
    }
}