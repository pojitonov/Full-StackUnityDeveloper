using System;
using Modules.Money;
using Zenject;

namespace Game.UI
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
            _moneyView.SetMoney(_moneyStorage.Money.ToString());
            _moneyStorage.OnMoneyEarned += OnMoneyEarned;
            _moneyStorage.OnMoneySpent += OnMoneySpent;
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }

        public void Dispose()
        {
            _moneyStorage.OnMoneyEarned -= OnMoneyEarned;
            _moneyStorage.OnMoneySpent -= OnMoneySpent;
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyEarned(int newvalue, int range)
        {
            _moneyView.AddMoney(newvalue.ToString());
        }

        private void OnMoneySpent(int newvalue, int range)
        {
            _moneyView.RemoveMoney(newvalue.ToString());
        }

        private void OnMoneyChanged(int newvalue, int prevvalue)
        {
            _moneyView.ChangeMoney(newvalue.ToString());
        }
    }
}