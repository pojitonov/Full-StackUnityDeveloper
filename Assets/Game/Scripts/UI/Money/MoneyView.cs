using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Game.UI.Money
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _moneyText;

        [SerializeField]
        private Image _icon;

        public void ChangeMoney(string money)
        {
            _moneyText.text = money;
        }

        public Vector3 GetCoinPosition()
        {
            return _icon.transform.position;
        }
    }
}