using Modules.Planets;

namespace Game.UI.Signals
{
    public class OpenPlanetPopupSignal
    {
        public IPlanet Planet { get; }

        public OpenPlanetPopupSignal(IPlanet planet)
        {
            Planet = planet;
        }
    }
}