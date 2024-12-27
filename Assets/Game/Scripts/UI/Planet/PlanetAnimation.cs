// using System;
// using System.Collections;
// using UnityEngine;
// using DG.Tweening;
//
// namespace Modules.UI
// {
//     public class PlanetAnimation : MonoBehaviour
//     {
//         [SerializeField]
//         private GameObject _coinStartPosition;
//
//         [SerializeField]
//         private float _flyDuration = 1f;
//
//         private FloatingAnimation floatingComponent;
//         private Vector3 initialTransform;
//         private Coroutine _timerCoroutine;
//
//         private void Awake()
//         {
//             floatingComponent = _coinStartPosition.GetComponent<FloatingAnimation>();
//             initialTransform = _coinStartPosition.transform.position;
//         }
//
//         public void StartTimerAnimation(float time, float progress)
//         {
//             if (_timerCoroutine != null)
//             {
//                 StopCoroutine(_timerCoroutine);
//             }
//
//             _timerCoroutine = StartCoroutine(AnimateTimer(time, progress));
//         }
//
//         public void StartCoinAnimation(Action OnComplete)
//         {
//             _animation?.FlyCoinToWidget(_moneyView.GetCoinPosition(), OnComplete);
//             if (_animation == null)
//                 OnComplete?.Invoke();
//         }
//
//         private IEnumerator AnimateTimer(float time, float progress)
//         {
//             while (time > 0)
//             {
//                 ShowTimer(true);
//                 ShowCoin(false);
//
//                 _timerText.text = time.ToString("0m:00s");
//                 _timerProgress.fillAmount = progress;
//                 yield return null;
//             }
//
//             _timerText.text = "0m:00s";
//             _timerProgress.fillAmount = 1f;
//
//             ShowTimer(false);
//             ShowCoin(true);
//         }
//     }
// }