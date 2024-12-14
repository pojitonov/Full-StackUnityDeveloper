using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Sirenix.OdinInspector;

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
        private Image _avatar;

        [SerializeField]
        private Button _button;

        private IPlanetPopupPresenter _popupPresenter;

        [Inject]
        public void Construct(IPlanetPopupPresenter popupPresenter)
        {
            _popupPresenter = popupPresenter;
        }
        
        [Button]
        public void Show()
        {
            UpdateView();

            _button.onClick.AddListener(_popupPresenter.OnButtonClick);
            _button.interactable = _popupPresenter.IsButtonEnabled;
            
            gameObject.SetActive(true);
        }

        [Button]
        public void Hide()
        {
            _button.onClick.RemoveListener(_popupPresenter.OnButtonClick);
            
            gameObject.SetActive(false);
        }

        private void UpdateView()
        {
            _title.text = _popupPresenter.Title;
            _population.text = _popupPresenter.Population;
            _level.text = _popupPresenter.Level;
            _income.text = _popupPresenter.Income;
            _price.text = _popupPresenter.Price;
            _avatar.sprite = _popupPresenter.Avatar;
        }
    }
}