using System;
using Game.UI.Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.Popup
{
    public class PlanetPopupView : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField]
        private TMP_Text _title;

        [SerializeField]
        private TMP_Text _population;

        [SerializeField]
        private TMP_Text _level;

        [SerializeField]
        private TMP_Text _income;

        [SerializeField]
        private TMP_Text _price;

        [SerializeField]
        private TMP_Text _buttonText;

        [SerializeField]
        private GameObject _buttonPrice;

        [SerializeField]
        private Image _avatar;

        [SerializeField]
        private Button _upgradeButton;

        [SerializeField]
        private Button _closeButton;

        private IPlanetPopupPresenter _popupPresenter;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(IPlanetPopupPresenter popupPresenter, SignalBus signalBus)
        {
            _popupPresenter = popupPresenter;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<OpenPlanetPopupSignal>(ConfigurePopup);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<OpenPlanetPopupSignal>(ConfigurePopup);
        }

        private void ConfigurePopup(OpenPlanetPopupSignal signal)
        {
            _popupPresenter.SetPlanet(signal.Planet);
            Show();
        }

        private void Show()
        {
            _upgradeButton.onClick.AddListener(_popupPresenter.OnUpgradeButtonClick);
            _closeButton.onClick.AddListener(Hide);
            _popupPresenter.OnStateChanged += UpdateView;

            gameObject.SetActive(true);
            UpdateView();
        }

        private void Hide()
        {
            _upgradeButton.onClick.RemoveListener(_popupPresenter.OnUpgradeButtonClick);
            _closeButton.onClick.RemoveListener(Hide);
            _popupPresenter.OnStateChanged -= UpdateView;

            gameObject.SetActive(false);
        }

        private void UpdateView()
        {
            _title.text = _popupPresenter.Title;
            _population.text = _popupPresenter.Population;
            _level.text = _popupPresenter.Level;
            _income.text = _popupPresenter.Income;
            _price.text = _popupPresenter.Price;
            _buttonText.text = _popupPresenter.Button;
            _avatar.sprite = _popupPresenter.Avatar;
            _buttonPrice.SetActive(!_popupPresenter.IsMaxLevel);
            _upgradeButton.interactable = _popupPresenter.IsUpgradeButtonEnabled;
        }
    }
}