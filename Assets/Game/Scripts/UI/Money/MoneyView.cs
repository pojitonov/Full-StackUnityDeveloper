using Modules.UI;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text moneyText;

        [SerializeField]
        private CounterAnimation _animation;

        public void SetMoney(string money)
        {
            moneyText.text = money;
            _animation?.Initialize(moneyText, money);
        }

        public void ChangeMoney(string money)
        {
            moneyText.text = money;
            _animation?.UpdateText(money);
        }
    }
}