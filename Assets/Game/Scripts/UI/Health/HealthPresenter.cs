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

        protected override void OnInit()
        {
            _gameContext = GameContext.Instance;
            _character = _gameContext.GetCharacter();
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
            var healthMax = _character.GetHealth().Value;
            float normalizedValue = (float)(value - 0) / (healthMax - 0);

            _view.SetText(value.ToString("D2"));
            _view.SetProgress(normalizedValue);
        }
    }
}