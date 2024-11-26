using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class GameManager : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IScore _score;
        private readonly IDifficulty _difficulty;
        private readonly IGameUI _gameUI;

        public GameManager(ISnake snake, IScore score, IDifficulty difficulty, IGameUI gameUI)
        {
            _snake = snake;
            _score = score;
            _difficulty = difficulty;
            _gameUI = gameUI;
        }

        public void Initialize()
        {
            _snake.OnSelfCollided += HandleGameOver;
            _score.OnStateChanged += OnScoreChanged;
            _difficulty.OnStateChanged += OnDifficultyChanged;
            UpdateUI();
        }

        public void Dispose()
        {
            _snake.OnSelfCollided -= HandleGameOver;
            _score.OnStateChanged -= OnScoreChanged;
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }

        private void HandleGameOver()
        {
            GameOver(false);
        }

        private void GameOver(bool isWin)
        {
            _gameUI.GameOver(isWin);
        }

        private void UpdateUI()
        {
            _gameUI.SetScore(_score.Current.ToString());
            _gameUI.SetDifficulty(_difficulty.Current + 1, _difficulty.Max);
        }

        private void OnDifficultyChanged()
        {
            _gameUI.SetDifficulty(_difficulty.Current + 1, _difficulty.Max);
        }
        
        private void OnScoreChanged(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
    }
}