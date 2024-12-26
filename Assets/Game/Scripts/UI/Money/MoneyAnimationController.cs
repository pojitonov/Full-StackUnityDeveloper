using System;
using Modules.Money;
using Modules.UI;
using Zenject;

namespace Game.UI
{
    public sealed class MoneyAnimationController : IInitializable, IDisposable
    {
        private readonly MoneyStorage _moneyStorage;
        private readonly MoneyAnimation _moneyAnimation;

        public MoneyAnimationController(MoneyStorage moneyStorage, MoneyAnimation moneyAnimation)
        {
            _moneyStorage = moneyStorage;
            _moneyAnimation = moneyAnimation;
        }

        public void Initialize()
        {
            _moneyAnimation.Initialize(_moneyStorage.Money.ToString());
            _moneyStorage.OnMoneyChanged += StartAnimation;
        }

        public void Dispose()
        {
            _moneyStorage.OnMoneyChanged -= StartAnimation;
        }

        private void StartAnimation(int newValue, int previousValue)
        {
            _moneyAnimation.UpdateText(newValue.ToString());
        }
    }
}