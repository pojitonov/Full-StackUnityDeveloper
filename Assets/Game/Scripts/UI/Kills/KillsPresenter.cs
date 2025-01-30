using System;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Presenters;
using Game.Gameplay;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class KillsPresenter : Presenter
    {
        [SerializeField] private TextMeshProUGUI _text;

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
            _character.GetHealth().Observe(OnValueChanged);
        }

        private void OnValueChanged(int value)
        {
            _text.SetText(value.ToString());
        }
    }
}