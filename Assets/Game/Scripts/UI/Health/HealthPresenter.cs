using System;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Presenters;
using Game.Gameplay;
using UnityEngine;

namespace Game.UI
{
    public class HealthPresenter : Presenter
    {
        [SerializeField] private StatView _view;

        private IGameContext _gameContext;
        private IEntity _character;
        private int _healthMax;
        private int _healthMin;

        protected override void OnInit()
        {
            _gameContext = GameContext.Instance;
            _character = _gameContext.GetCharacter();
            _healthMax = _character.GetHealth().Value;
        }

        protected override void OnShow()
        {
            _character.GetHealth().Observe(OnValueChanged);
        }

        protected override void OnHide()
        {
            _character.GetHealth().Unsubscribe(OnValueChanged);
        }

        private void OnValueChanged(int value)
        {
            _view.SetText(value.ToString());
            float normalizedValue = (float)(value - _healthMin) / (_healthMax - _healthMin);
            _view.SetProgress(normalizedValue);
        }
    }
}