using Atomic.Elements;
using Atomic.Entities;
using Atomic.Presenters;
using Game.Gameplay;
using Modules.Gameplay;
using UnityEngine;

namespace Game.UI
{
    public class AmmoPresenter : Presenter
    {
        [SerializeField] private StatView _view;

        private IGameContext _gameContext;
        private IEntity _character;
        private Ammo _ammo;
        private int _ammoCount;

        protected override void OnInit()
        {
            _gameContext = GameContext.Instance;
            _character = _gameContext.GetCharacter();
            _ammo = _character.GetWeapon().GetAmmo();
            _ammoCount = _ammo.Count;
            SetValue(_ammoCount);
        }

        protected override void OnShow()
        {
            _ammo.OnCountChanged += OnValueChanged;
        }

        protected override void OnHide()
        {
            _ammo.OnCountChanged -= OnValueChanged;
        }

        private void OnValueChanged(int value)
        {
            SetValue(value);
        }

        private void SetValue(int value)
        {
            float normalizedValue = (float)(value - 0) / (_ammoCount - 0);
            _view.SetText(value.ToString("D2"));
            _view.SetProgress(normalizedValue);
        }
    }
}