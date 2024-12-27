using System;
using Modules.Money;
using Zenject;

namespace Game.UI.Money
{
    public sealed class MoneyAnimationController : IInitializable, IDisposable
    {
        private readonly MoneyStorage _money;
        private readonly MoneyAnimation _animation;

        public MoneyAnimationController(MoneyStorage money, MoneyAnimation animation)
        {
            _money = money;
            _animation = animation;
        }

        public void Initialize()
        {
            _animation.Initialize(_money.Money.ToString());
            _money.OnMoneyChanged += StartAnimation;
        }

        public void Dispose()
        {
            _money.OnMoneyChanged -= StartAnimation;
        }

        private void StartAnimation(int newValue, int previousValue)
        {
            _animation.UpdateText(newValue.ToString());
        }
    }
}