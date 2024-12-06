using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class DifficultyController : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly IGameUI _gameUI;

        public Action<bool> OnGameOver;   

        public DifficultyController(IDifficulty difficulty, IGameUI gameUI)
        {
            _difficulty = difficulty;
            _gameUI = gameUI;
        }

        public void Initialize()
        {
            UpdateUI();
            _difficulty.OnStateChanged += OnDifficultyChanged;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }

        private void OnDifficultyChanged()
        {
            UpdateUI();
            if (_difficulty.Current == _difficulty.Max)
            {
                TriggerGameOver(true);
            }
        }

        private void UpdateUI()
        {
            _gameUI.SetDifficulty(_difficulty.Current + 1, _difficulty.Max);
        }
        
        private void TriggerGameOver(bool isWin)
        {
            OnGameOver?.Invoke(isWin);
        }
    }
}