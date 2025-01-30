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

        protected override void OnInit()
        {
            _gameContext = GameContext.Instance;
        }

        protected override void OnShow()
        {
            _gameContext.GetKills().Observe(OnValueChanged);
        }

        protected override void OnHide()
        {
            _gameContext.GetKills().Unsubscribe(OnValueChanged);
        }

        private void OnValueChanged(int value)
        {
            _text.text = value.ToString();
        }
    }
}