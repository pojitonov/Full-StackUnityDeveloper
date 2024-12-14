using Game.UI.Planet;
using Modules.Planets;
using System.Collections.Generic;
using Zenject;

namespace Game.UI
{
    public class PlanetPresenterInitializer : IInitializable
    {
        private readonly PlanetView[] _planetViews;
        private readonly PlanetPresenterFactory _factory;
        private readonly List<IPlanet> _planets;

        public PlanetPresenterInitializer(
            PlanetView[] planetViews,
            PlanetPresenterFactory factory,
            List<IPlanet> planets)
        {
            _planetViews = planetViews;
            _factory = factory;
            _planets = planets;
        }

        public void Initialize()
        {
            for (int i = 0; i < _planetViews.Length; i++)
            {
                PlanetView view = _planetViews[i];
                IPlanet planet = _planets[i];
                PlanetPresenter presenter = _factory.Create(view, planet);
                presenter.Initialize();
            }
        }
    }
}