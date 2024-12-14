using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.UI.Planet
{
    public class PlanetPresenterFactory : PlaceholderFactory<PlanetView, IPlanet, PlanetPresenter>
    {
    }
}