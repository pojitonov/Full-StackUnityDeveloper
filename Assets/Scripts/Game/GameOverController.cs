using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class GameOverController : IInitializable, IDisposable
    {
        private readonly SnakeManager _snakeManager;
        private readonly IGameUI _gameUI;
        private readonly DifficultyController _difficultyController;

        public GameOverController(SnakeManager snakeManager, DifficultyController difficultyController, IGameUI gameUI)
        {
            _snakeManager = snakeManager;
            _difficultyController = difficultyController;
            _gameUI = gameUI;
        }

        public void Initialize()
        {
            _snakeManager.OnGameOver += HandleGameOver;
            _difficultyController.OnGameOver += HandleGameOver;
        }

        public void Dispose()
        {
            _snakeManager.OnGameOver -= HandleGameOver;
            _difficultyController.OnGameOver -= HandleGameOver;
        }

        private void HandleGameOver(bool isWin)
        {
            _gameUI.GameOver(isWin);
            _snakeManager.DeactivateSnake();
        }
    }
}