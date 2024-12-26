using Modules.UI;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Game.UI
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text moneyText;

        [SerializeField]
        private Image _icon;
        
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

        public Vector3 GetCoinPosition()
        {
            return _icon.transform.position;
        }
    }
}