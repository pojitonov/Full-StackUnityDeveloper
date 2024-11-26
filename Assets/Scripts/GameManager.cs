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
        private readonly SnakeManager _snakeManager;

        public GameManager(ISnake snake, IScore score, IDifficulty difficulty, IGameUI gameUI,
            SnakeManager snakeManager)
        {
            _snake = snake;
            _score = score;
            _difficulty = difficulty;
            _gameUI = gameUI;
            _snakeManager = snakeManager;
        }

        public void Initialize()
        {
            _snake.OnSelfCollided += HandleSelfCollision;
            _snakeManager.OnGameOver += HandleGameOver;
            _score.OnStateChanged += OnScoreChanged;
            _difficulty.OnStateChanged += OnDifficultyChanged;
            UpdateUI();
        }

        public void Dispose()
        {
            _snake.OnSelfCollided -= HandleSelfCollision;
            _snakeManager.OnGameOver -= HandleGameOver;
            _score.OnStateChanged -= OnScoreChanged;
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }

        private void HandleSelfCollision()
        {
            HandleGameOver(false);
        }
        
        private void HandleGameOver(bool isWin)
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