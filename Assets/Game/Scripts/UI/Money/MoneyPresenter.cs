using System;
using Modules.Money;
using Zenject;

namespace Game.UI.Money
{
    public sealed class MoneyPresenter : IInitializable, IDisposable
    {
        private readonly MoneyStorage _moneyStorage;
        private readonly MoneyView _moneyView;

        public MoneyPresenter(MoneyStorage moneyStorage, MoneyView moneyView)
        {
            _moneyStorage = moneyStorage;
            _moneyView = moneyView;
        }

        public void Initialize()
        {
            _moneyView.ChangeMoney(_moneyStorage.Money.ToString());
            _moneyStorage.OnMoneyEarned += ChangeMoney;
            _moneyStorage.OnMoneySpent += ChangeMoney;
        }

        public void Dispose()
        {
            _moneyStorage.OnMoneyEarned -= ChangeMoney;
            _moneyStorage.OnMoneySpent -= ChangeMoney;
        }

        private void ChangeMoney(int newValue, int _)
        {
            _moneyView.ChangeMoney(newValue.ToString());
        }
    }
}