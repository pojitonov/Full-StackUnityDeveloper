using Atomic.Elements;
using Atomic.Entities;
using Atomic.Presenters;
using Game.Gameplay;
using UnityEngine;

namespace Game.UI
{
    public class AmmoPresenter : Presenter
    {
        [SerializeField] private StatView _view;

        private IGameContext _gameContext;
        private IEntity _character;
        private int _ammoMax;
        private int _ammoMin;

        protected override void OnInit()
        {
            _gameContext = GameContext.Instance;
            _character = _gameContext.GetCharacter();
            _ammoMax = _character.GetHealth().Value;
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
            float normalizedValue = (float)(value - _ammoMin) / (_ammoMax - _ammoMin);
            _view.SetProgress(normalizedValue);
        }
    }
}