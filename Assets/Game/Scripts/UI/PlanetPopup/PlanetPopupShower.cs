using Modules.Planets;
using Sirenix.OdinInspector;

namespace Game.UI.Planets
{
    public class PlanetPopupShower
    {
        private readonly PlanetPopupPresenter _presenter;
        private readonly PlanetPopupView _view;

        public PlanetPopupShower(PlanetPopupPresenter presenter, PlanetPopupView view)
        {
            _presenter = presenter;
            _view = view;
        }

        [Button]
        public void Show(IPlanet planet)
        {
            _presenter.SetPlanet(planet);
            _view.Show();
        }
    }
}