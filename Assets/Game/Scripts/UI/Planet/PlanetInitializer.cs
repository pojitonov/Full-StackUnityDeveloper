using Game.UI.Planet;
using Modules.Planets;
using System.Collections.Generic;
using Zenject;

namespace Game.UI.Planet
{
    public class PlanetInitializer : IInitializable
    {
        private readonly PlanetView[] _planetViews;
        private readonly List<IPlanet> _planets;
        private readonly PlanetPresenterFactory _presenterFactory;
        private readonly CoinAnimationControllerFactory _controllerFactory;

        public PlanetInitializer(
            PlanetView[] planetViews,
            PlanetPresenterFactory presenterFactory,
            CoinAnimationControllerFactory controllerFactory,
            List<IPlanet> planets)
        {
            _planetViews = planetViews;
            _presenterFactory = presenterFactory;
            _controllerFactory = controllerFactory;
            _planets = planets;
        }

        public void Initialize()
        {
            for (int i = 0; i < _planetViews.Length; i++)
            {
                PlanetView view = _planetViews[i];
                IPlanet planet = _planets[i];
                CoinAnimation animation = view.GetComponent<CoinAnimation>();
                PlanetPresenter presenter = _presenterFactory.Create(view, planet);
                CoinAnimationController controller = _controllerFactory.Create(view, planet, animation);
                
                presenter.Initialize();
                controller.Initialize();
            }
        }
    }
}