using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class ScoreController : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly IGameUI _gameUI;

        public ScoreController(IScore score, IGameUI gameUI)
        {
            _score = score;
            _gameUI = gameUI;
        }

        public void Initialize()
        {
            UpdateUI();
            _score.OnStateChanged += OnScoreChanged;
        }

        public void Dispose()
        {
            _score.OnStateChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int _)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            _gameUI.SetScore(_score.Current.ToString());
        }
    }
}