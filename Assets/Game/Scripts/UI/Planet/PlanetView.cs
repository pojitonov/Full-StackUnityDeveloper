using System;
using System.Collections;
using Modules.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Planet
{
    public class PlanetView : MonoBehaviour
    {
        public event Action OnPlanetClick;
        public event Action OnPlanetHoldClick;

        [SerializeField]
        private GameObject _incomePrefab;

        [SerializeField]
        private GameObject _pricePrefab;

        [SerializeField]
        private GameObject _coinPrefab;

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private Image _lock;

        [SerializeField]
        private TMP_Text _timerText;

        [SerializeField]
        private Image _timerProgress;

        [SerializeField]
        private TMP_Text _price;

        [SerializeField]
        private SmartButton _button;

        [SerializeField]
        private FlyingAnimation _animation;

        private Coroutine _timerCoroutine;

        public void Awake()
        {
            _button.OnClick += HandlePlanetClick;
            _button.OnHold += HandlePlanetHoldClick;
        }

        public void OnDestroy()
        {
            _button.OnClick -= HandlePlanetClick;
            _button.OnHold -= HandlePlanetHoldClick;
        }

        private void HandlePlanetClick()
        {
            OnPlanetClick?.Invoke();
        }

        private void HandlePlanetHoldClick()
        {
            OnPlanetHoldClick?.Invoke();
        }

        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }

        public void SetTime(string time)
        {
            _timerText.text = time;
        }

        public void SetPrice(string price)
        {
            _price.text = price;
        }

        public void ShowCoin(bool show)
        {
            _coinPrefab.gameObject.SetActive(show);
        }

        public void ShowLock(bool locked)
        {
            _lock.enabled = locked;
        }

        public void ShowTimer(bool show)
        {
            _incomePrefab.gameObject.SetActive(show);
        }

        public void ShowPrice(bool show)
        {
            _pricePrefab.gameObject.SetActive(show);
        }

        public void StartTimerAnimation(float time, float progress)
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
            }

            _timerCoroutine = StartCoroutine(AnimateTimer(time, progress));
        }

        public void StartCoinAnimation(Action OnComplete)
        {
            _animation?.FlyCoinToWidget(OnComplete);
            if (_animation == null)
                OnComplete?.Invoke();
        }

        private IEnumerator AnimateTimer(float time, float progress)
        {
            while (time > 0)
            {
                ShowTimer(true);
                ShowCoin(false);

                _timerText.text = time.ToString("0m:00s");
                _timerProgress.fillAmount = progress;
                yield return null;
            }

            _timerText.text = "0m:00s";
            _timerProgress.fillAmount = 1f;

            ShowTimer(false);
            ShowCoin(true);
        }
    }
}