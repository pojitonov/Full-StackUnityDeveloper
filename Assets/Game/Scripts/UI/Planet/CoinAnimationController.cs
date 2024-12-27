using System;
using Modules.Planets;
using Modules.UI;
using Zenject;

namespace Game.UI
{
    public sealed class CoinAnimationController : IInitializable, IDisposable
    {
        private readonly IPlanet _planet;
        private readonly CoinAnimation _coinAnimation;

        public CoinAnimationController(IPlanet planet, CoinAnimation coinAnimation)
        {
            _planet = planet;
            _coinAnimation = coinAnimation;
        }

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }
        
        // private void OnPlanetClick()
        // {
        //     if (_planet.IsIncomeReady)
        //     {
        //         _view.StartCoinAnimation(() => { _planet.GatherIncome(); });
        //     }
        // }
        //
    }
}