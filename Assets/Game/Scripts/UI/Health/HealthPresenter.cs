using Atomic.Entities;
using Atomic.Presenters;
using Game.Gameplay;
using Modules.Gameplay;
using UnityEngine;

namespace Game.UI
{
    public class HealthPresenter : Presenter
    {
        [SerializeField] private StatView _view;
        [SerializeField] private HealthScreen _healthScreen;

        private IGameContext _gameContext;
        private IEntity _character;
        private Health _health;
        
        private float NormalizedValue => (float)(_health.GetCurrent() - 0) / (_health.GetMax() - 0);
        
        protected override void OnInit()
        {
            _gameContext = GameContext.Instance;
            _character = _gameContext.GetCharacter();
            _health = _character.GetHealth();
            
            UpdateView(_health.GetCurrent());
            UpdateHealthScreen(_health.GetCurrent());
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
            UpdateHealthScreen(value);
        }

        private void UpdateView(int value)
        {
            _view.SetText(value.ToString("D2"));
            _view.SetProgress(NormalizedValue);
        }
        
        private void UpdateHealthScreen(int currentHealth)
        {
            float percent = NormalizedValue;
            _healthScreen.ChangePercent(percent);
            _healthScreen.TakeDamage(_health.GetMax() - currentHealth);
        }
    }
}