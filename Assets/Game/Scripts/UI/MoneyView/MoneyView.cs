using Modules.UI;
using UnityEngine;
using TMPro;
using Zenject;

namespace Game.UI
{
    [RequireComponent(typeof(CounterAnimation))]
    public class MoneyView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text moneyText;

        [Inject]
        private CounterAnimation _counterAnimation;

        public void SetMoney(string money)
        {
            _counterAnimation.Initialize(moneyText, money);
        }

        public void AddMoney(string money)
        {
            _counterAnimation.UpdateText(money);
        }

        public void RemoveMoney(string money)
        {
            _counterAnimation.UpdateText(money);
        }

        public void ChangeMoney(string money)
        {
            _counterAnimation.UpdateText(money);
        }
    }
}