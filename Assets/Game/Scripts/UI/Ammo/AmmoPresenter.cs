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
        
        private float NormalizedValue => (float)(_ammo.Count - 0) / (_ammo.Capacity - 0);
        
        protected override void OnInit()
        {
            _gameContext = GameContext.Instance;
            _character = _gameContext.GetCharacter();
            _ammo = _character.GetWeapon().GetAmmo();
            
            UpdateView(_ammo.Count);
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
            UpdateView(value);
        }

        private void UpdateView(int value)
        {
            _view.SetText(value.ToString("D2"));
            _view.SetProgress(NormalizedValue);
        }
    }
}