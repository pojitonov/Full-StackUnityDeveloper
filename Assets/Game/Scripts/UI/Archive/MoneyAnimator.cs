using System.Collections;
using UnityEngine;
using TMPro;

namespace Game.UI.Money
{
    public class MoneyAnimator : MonoBehaviour
    {
        // [SerializeField]
        // private TMP_Text _moneyText;
        //
        // [SerializeField]
        // private float _duration = 1f;
        //
        // [SerializeField]
        // private int _fps = 30;
        //
        // private int _currentValue;
        // private Coroutine _countingCoroutine;
        //
        // public void Initialize(string startValue)
        // {
        //     _currentValue = ConvertStringToInt(startValue);
        //     _moneyText.text = _currentValue.ToString();
        // }
        //
        // public void UpdateText(string newValue)
        // {
        //     int targetValue = ConvertStringToInt(newValue);
        //
        //     if (_countingCoroutine != null)
        //     {
        //         StopCoroutine(_countingCoroutine);
        //     }
        //
        //     _countingCoroutine = StartCoroutine(CountText(targetValue));
        // }
        //
        // private IEnumerator CountText(int targetValue)
        // {
        //     WaitForSeconds wait = new WaitForSeconds(_duration / _fps);
        //     int startValue = _currentValue;
        //     int totalFrames = Mathf.Max(1, Mathf.CeilToInt(_fps * _duration));
        //     int stepAmount = Mathf.Max(1, Mathf.Abs(targetValue - startValue) / totalFrames) *
        //                      (int)Mathf.Sign(targetValue - startValue);
        //
        //     while (_currentValue != targetValue)
        //     {
        //         if (Mathf.Abs(targetValue - _currentValue) < Mathf.Abs(stepAmount))
        //         {
        //             _currentValue = targetValue;
        //         }
        //         else
        //         {
        //             _currentValue += stepAmount;
        //         }
        //
        //         _moneyText.text = _currentValue.ToString();
        //         yield return wait;
        //     }
        // }
        //
        // private int ConvertStringToInt(string value)
        // {
        //     return int.TryParse(value, out var result) ? result : 0;
        // }
    }
}
