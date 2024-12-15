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

        public void ShowUnlockedState(bool isUnlocked)
        {
            ShowLock(!isUnlocked);
            ShowPrice(!isUnlocked);
            if (isUnlocked)
            {
                StartTimerToShowCoin();
            }
            else
            {
                ShowTimer(false);
                ShowCoin(false);
            }
        }

        private void ShowLock(bool locked)
        {
            _lock.enabled = locked;
        }

        private void ShowTimer(bool show)
        {
            _incomePrefab.gameObject.SetActive(show);
        }

        private void UpdateTimer(float progress)
        {
            SetTime(progress.ToString("0m:00s"));
            _timerProgress.fillAmount = progress;
        }

        private void ShowPrice(bool show)
        {
            _pricePrefab.gameObject.SetActive(show);
        }

        private void StartTimerToShowCoin()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
            }

            _timerCoroutine = StartCoroutine(TimerToCoinRoutine());
        }

        private IEnumerator TimerToCoinRoutine()
        {
            ShowTimer(true);
            ShowCoin(false);
            UpdateTimer(0);

            float duration = 1f;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float progress = Mathf.Clamp01(elapsed / duration);
                UpdateTimer(progress);
                yield return null;
            }

            ShowTimer(false);
            ShowCoin(true);
        }
    }
}