using System;
using Game.UI.Signals;
using Zenject;

namespace Game.UI.Planet
{
    public class CoinAnimationController : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        public CoinAnimationController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<CoinGatheredSignal>(StartAnimation);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<CoinGatheredSignal>(StartAnimation);
        }

        private void StartAnimation(CoinGatheredSignal signal)
        {
            var coinAnimation = signal.View.GetComponent<CoinAnimation>();
            if (coinAnimation != null)
            {
                coinAnimation.StartAnimation();
            }
        }
    }
}