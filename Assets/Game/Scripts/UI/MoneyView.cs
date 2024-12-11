using UnityEngine;
using TMPro;

namespace Game.UI
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text moneyText;

        public void SetMoney(string money)
        {
            moneyText.text = money;
        }

        public void AddMoney(string money)
        {
            moneyText.text = money;
        }

        public void RemoveMoney(string money)
        {
            moneyText.text = money;
        }

        public void ChangeMoney(string money)
        {
            moneyText.text = money;
        }
    }
}