using Atomic.Presenters;
using Game.Gameplay;
using Modules.Gameplay;
using UnityEngine;

namespace Game.UI
{
    public class HealthScreenPresenter : Presenter
    {
        [SerializeField] private HealthScreen _healthScreen;

        private IGameContext _gameContext;
        private Health _health;
        
        protected override void OnInit()
        {
            _gameContext = GameContext.Instance;
            _health = _gameContext.GetCharacter().GetHealth();
            UpdateScreen(_health.GetCurrent());
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
            UpdateScreen(value);
        }

        private void UpdateScreen(int value)
        {
            _healthScreen.ChangePercent(_health.GetPercent());
            _healthScreen.TakeDamage(_health.GetMax() - value);
        }
    }
}