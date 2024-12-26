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
        private MoneyAnimation _animation;

        public void SetMoney(string money)
        {
            moneyText.text = money;
            _animation?.Initialize(moneyText, money);
        }

        public void ChangeMoney(string money)
        {
            moneyText.text = money;
        }

        public void StartAnimation(string money)
        {
            _animation?.UpdateText(money);
        }
    }
}