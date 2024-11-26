using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class GameManager : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly IGameUI _gameUI;

        public GameManager(IScore score, IGameUI gameUI)
        {
            _score = score;
            _gameUI = gameUI;
        }

        public void Initialize()
        {
            _score.OnStateChanged += OnScoreChanged;
            GameStart();
        }

        public void Dispose()
        {
            _score.OnStateChanged -= OnScoreChanged;
        }

        private void GameStart()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            _gameUI.SetScore(_score.Current.ToString());
        }

        private void OnScoreChanged(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
    }
}