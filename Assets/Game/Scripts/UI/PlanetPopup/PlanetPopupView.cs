using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.Planets
{
    public class PlanetPopupView : MonoBehaviour
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

        [Inject]
        public void Construct(IPlanetPopupPresenter popupPresenter)
        {
            _popupPresenter = popupPresenter;
        }

        public void Show()
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
            _popupPresenter.Unsubscribe();
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