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
            _targetValue = money;
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
            int startValue = _currentValue;
            int totalChange = _targetValue - startValue;
            int totalFrames = Mathf.Max(1, Mathf.CeilToInt(_duration * _fps));
            float stepAmount = (float)totalChange / totalFrames;
            WaitForSeconds wait = new WaitForSeconds(1f / _fps);

            for (int frame = 0; frame < totalFrames; frame++)
            {
                _currentValue = Mathf.RoundToInt(startValue + stepAmount * (frame + 1));
                
                if (Mathf.Abs(_currentValue - _targetValue) < Mathf.Abs(stepAmount))
                {
                    _currentValue = _targetValue;
                }

                _moneyText.text = _currentValue.ToString();

                if (_currentValue == _targetValue)
                    break;

                yield return wait;
            }

            _currentValue = _targetValue;
            _moneyText.text = _currentValue.ToString();
            _countingCoroutine = null;
        }
    }
}
