using Modules.Money;
using Modules.UI;
using UnityEngine;
using TMPro;
using Zenject;

namespace Game.UI
{
    [RequireComponent(typeof(CounterAnimation))]
    public class MoneyWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text moneyText;

        private CounterAnimation _counterAnimation;
        private MoneyStorage _moneyStorage;

        [Inject]
        public void Construct(MoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }

        private void Awake()
        {
            _counterAnimation = FindObjectOfType<CounterAnimation>();
        }

        private void OnEnable()
        {
            _counterAnimation.Initialize(moneyText, _moneyStorage.Money);
            moneyText.text = _moneyStorage.Money.ToString();

            _moneyStorage.OnMoneyEarned += OnMoneyEarned;
            _moneyStorage.OnMoneySpent += OnMoneySpent;
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }

        private void OnDisable()
        {
            _moneyStorage.OnMoneyEarned -= OnMoneyEarned;
            _moneyStorage.OnMoneySpent -= OnMoneySpent;
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyEarned(int newvalue, int range)
        {
            moneyText.text = _moneyStorage.Money.ToString();
        }

        private void OnMoneySpent(int newvalue, int range)
        {
            moneyText.text = _moneyStorage.Money.ToString();
        }

        private void OnMoneyChanged(int newvalue, int prevvalue)
        {
            moneyText.text = _moneyStorage.Money.ToString();
            _counterAnimation.UpdateText(newvalue);
        }
    }
}