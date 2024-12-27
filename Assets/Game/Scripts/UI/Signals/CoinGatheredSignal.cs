using Game.UI.Planet;

namespace Game.UI.Signals
{
    public class CoinGatheredSignal
    {
        public PlanetView View;

        public CoinGatheredSignal(PlanetView view)
        {
            View = view;
        }
    }
}