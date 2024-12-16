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

        public void StartTimer(float progress)
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
            }

            _timerCoroutine = StartCoroutine(AnimateTimer(progress));
        }

        private IEnumerator AnimateTimer(float progress)
        {
            while (progress > 0)
            {
                ShowTimer(true);
                ShowCoin(false);

                _timerText.text = progress.ToString("0m:00s");
                _timerProgress.fillAmount = Mathf.Clamp01(1 - progress);

                yield return null;
            }

            _timerText.text = "0m:00s";
            _timerProgress.fillAmount = 1f;

            ShowTimer(false);
            ShowCoin(true);
        }
    }
}