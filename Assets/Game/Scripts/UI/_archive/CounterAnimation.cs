// using System.Collections;
// using UnityEngine;
// using TMPro;
//
// namespace Modules.UI
// {
//     public class CounterAnimation : MonoBehaviour
//     {
//         [SerializeField]
//         private float _duration = 1f;
//
//         [SerializeField]
//         private int _fps = 30;
//
//         private TMP_Text _text;
//         private int _currentValue;
//         private Coroutine _countingCoroutine;
//
//         public void Initialize(TMP_Text text, int startValue)
//         {
//             _text = text;
//             _currentValue = startValue;
//             _text.text = _currentValue.ToString();
//         }
//
//         public void UpdateText(int newValue)
//         {
//             if (_countingCoroutine != null)
//             {
//                 StopCoroutine(_countingCoroutine);
//             }
//
//             _countingCoroutine = StartCoroutine(CountText(newValue));
//         }
//
//         private IEnumerator CountText(int targetValue)
//         {
//             WaitForSeconds wait = new WaitForSeconds(_duration / _fps);
//             int startValue = _currentValue;
//             int totalFrames = Mathf.Max(1, Mathf.CeilToInt(_fps * _duration));
//             int stepAmount = Mathf.Max(1, Mathf.Abs(targetValue - startValue) / totalFrames) *
//                              (int)Mathf.Sign(targetValue - startValue);
//
//             while (_currentValue != targetValue)
//             {
//                 if (Mathf.Abs(targetValue - _currentValue) < Mathf.Abs(stepAmount))
//                 {
//                     _currentValue = targetValue;
//                 }
//                 else
//                 {
//                     _currentValue += stepAmount;
//                 }
//
//                 _text.text = _currentValue.ToString();
//                 yield return wait;
//             }
//         }
//     }
// }