using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class GameManager : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly IDifficulty _difficulty;
        private readonly IGameUI _gameUI;
        private readonly SnakeManager _snakeManager;

        public GameManager(IScore score, IDifficulty difficulty, IGameUI gameUI, SnakeManager snakeManager)
        {
            _score = score;
            _difficulty = difficulty;
            _gameUI = gameUI;
            _snakeManager = snakeManager;
        }

        public void Initialize()
        {
            _snakeManager.OnGameOver += HandleGameOver;
            _score.OnStateChanged += OnScoreChanged;
            _difficulty.OnStateChanged += OnDifficultyChanged;
            UpdateUI();
        }

        public void Dispose()
        {
            _snakeManager.OnGameOver -= HandleGameOver;
            _score.OnStateChanged -= OnScoreChanged;
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }

        private void OnDifficultyChanged()
        {
            UpdateUI();
            HandleEndOfTheGame();
        }

        private void OnScoreChanged(int score)
        {
            UpdateUI();
        }

        private void HandleGameOver(bool isWin)
        {
            _gameUI.GameOver(isWin);
            _snakeManager.DiactivateSnake();
        }

        private void HandleEndOfTheGame()
        {
            if (_difficulty.Current == _difficulty.Max)
            {
                HandleGameOver(true);
                _snakeManager.DiactivateSnake();
            }
        }

        private void UpdateUI()
        {
            _gameUI.SetScore(_score.Current.ToString());
            _gameUI.SetDifficulty(_difficulty.Current + 1, _difficulty.Max);
        }
    }
}