using System;
using Game.UI.Money;
using Game.UI.Signals;
using Modules.UI;
using Zenject;

namespace Game.UI.Planet
{
    public class CoinAnimationController : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly MoneyView _moneyView;
        private readonly ParticleAnimator _animator;

        public CoinAnimationController(SignalBus signalBus, MoneyView moneyView, ParticleAnimator animator)
        {
            _signalBus = signalBus;
            _moneyView = moneyView;
            _animator = animator;
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
            var money = signal.Money;
            var startPosition = signal.StartPosition;
            var endPosition = _moneyView.GetCoinPosition();
            _animator.Emit(startPosition, endPosition, 1f, () => _moneyView.AddMoney(money));
        }
    }
}