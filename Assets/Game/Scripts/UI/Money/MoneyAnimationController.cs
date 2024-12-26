using System;
using Modules.Money;
using Zenject;

namespace Game.UI
{
    public sealed class MoneyAnimationController : IInitializable, IDisposable
    {
        private readonly MoneyStorage _moneyStorage;
        private readonly MoneyView _moneyView;

        public MoneyAnimationController(MoneyStorage moneyStorage, MoneyView moneyView)
        {
            _moneyStorage = moneyStorage;
            _moneyView = moneyView;
        }

        public void Initialize()
        {
            _moneyStorage.OnMoneyChanged += StartAnimation;
        }

        public void Dispose()
        {
            _moneyStorage.OnMoneyChanged -= StartAnimation;
        }

        private void StartAnimation(int newValue, int previousValue)
        {
            _moneyView.StartAnimation(newValue.ToString());
        }
    }
}