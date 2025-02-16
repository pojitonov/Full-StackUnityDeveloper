using Atomic.Presenters;
using Game.Gameplay;
using Modules.Gameplay;
using UnityEngine;

namespace Game.UI
{
    public class HealthStatsPresenter : Presenter
    {
        [SerializeField] private StatView _view;

        private IGameContext _gameContext;
        private Health _health;
        
        protected override void OnInit()
        {
            _gameContext = GameContext.Instance;
            _health = _gameContext.GetCharacter().GetHealth();
            UpdateView(_health.GetCurrent());
        }

        protected override void OnShow()
        {
            _health.OnHealthChanged += OnValueChanged;
        }

        protected override void OnHide()
        {
            _health.OnHealthChanged -= OnValueChanged;
        }

        private void OnValueChanged(int value)
        {
            UpdateView(value);
        }

        private void UpdateView(int value)
        {
            _view.SetText(value.ToString("D2"));
            _view.SetProgress(_health.GetPercent());
        }
    }
}