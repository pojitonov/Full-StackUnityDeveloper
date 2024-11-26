using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class GameManager : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IScore _score;
        private readonly IGameUI _gameUI;
        private readonly CoinManager _coinManager;

        public GameManager(ISnake snake, IScore score, IGameUI gameUI, CoinManager coinManager)
        {
            _snake = snake;
            _score = score;
            _gameUI = gameUI;
            _coinManager = coinManager;
        }

        public void Initialize()
        {
            _snake.OnMoved += _coinManager.CheckForCoinCollision;
            _score.OnStateChanged += OnScoreChanged;
            GameStart();
        }

        public void Dispose()
        {
            _score.OnStateChanged -= OnScoreChanged;
            _snake.OnMoved -= _coinManager.CheckForCoinCollision;

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