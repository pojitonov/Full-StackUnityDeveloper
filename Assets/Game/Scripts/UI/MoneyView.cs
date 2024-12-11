using Modules.UI;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    [RequireComponent(typeof(CounterAnimation))]
    public class MoneyView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text moneyText;

        private CounterAnimation _counterAnimation;

        private void Awake()
        {
            _counterAnimation = FindObjectOfType<CounterAnimation>();
        }

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