using Modules.Planets;
using Zenject;

namespace Game.UI.Planet
{
    public class PlanetPresenterFactory : PlaceholderFactory<PlanetView, IPlanet, PlanetPresenter>
    {
    }
}