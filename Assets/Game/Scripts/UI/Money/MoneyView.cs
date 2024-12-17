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

        private CounterAnimation _animation;

        [Inject]
        public void Construct(CounterAnimation animation)
        {
            _animation = animation;
        }

        public void SetMoney(string money)
        {
            _animation.Initialize(moneyText, money);
        }

        public void AddMoney(string money)
        {
            _animation.UpdateText(money);
        }

        public void RemoveMoney(string money)
        {
            _animation.UpdateText(money);
        }

        public void ChangeMoney(string money)
        {
            _animation.UpdateText(money);
        }
    }
}