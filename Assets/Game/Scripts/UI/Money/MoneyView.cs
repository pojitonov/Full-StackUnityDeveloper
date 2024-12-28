using System.Collections;
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

        [SerializeField]
        private float _duration = 1f;

        [SerializeField]
        private int _fps = 30;

        private int _currentValue;
        private int _targetValue;
        private Coroutine _countingCoroutine;

        public Vector3 GetCoinPosition()
        {
            return _icon.transform.position;
        }

        public void ChangeMoney(int money)
        {
            _currentValue = money;
            _moneyText.text = money.ToString();
        }

        public void AddMoney(int money)
        {
            _targetValue += money;

            if (_countingCoroutine == null)
            {
                _countingCoroutine = StartCoroutine(AnimateText());
            }
        }

        private IEnumerator AnimateText()
        {
            WaitForSeconds wait = new WaitForSeconds(1f / _fps);

            while (_currentValue != _targetValue)
            {
                int stepAmount = Mathf.Max(1, Mathf.Abs(_targetValue - _currentValue) / _fps) *
                                 (int)Mathf.Sign(_targetValue - _currentValue);

                if (Mathf.Abs(_targetValue - _currentValue) < Mathf.Abs(stepAmount))
                {
                    _currentValue = _targetValue;
                }
                else
                {
                    _currentValue += stepAmount;
                }

                _moneyText.text = _currentValue.ToString();
                yield return wait;
            }

            _countingCoroutine = null;
        }
    }
}