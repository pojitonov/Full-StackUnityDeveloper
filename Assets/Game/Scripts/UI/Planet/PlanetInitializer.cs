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

        public PlanetInitializer(
            PlanetView[] planetViews,
            PlanetPresenterFactory presenterFactory,
            List<IPlanet> planets)
        {
            _planetViews = planetViews;
            _presenterFactory = presenterFactory;
            _planets = planets;
        }

        public void Initialize()
        {
            for (int i = 0; i < _planetViews.Length; i++)
            {
                PlanetView view = _planetViews[i];
                IPlanet planet = _planets[i];
                PlanetPresenter presenter = _presenterFactory.Create(view, planet);
                
                presenter.Initialize();
            }
        }
    }
}