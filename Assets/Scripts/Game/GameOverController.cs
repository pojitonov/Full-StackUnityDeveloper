using System;
using Zenject;

namespace SnakeGame
{
    public class GameOverController : IInitializable, IDisposable
    {
        private readonly DifficultyController _difficultyController;
        private readonly SnakeCollectCoinController _snakeCollectCoinController;
        private readonly IGameUI _gameUI;

        public GameOverController(DifficultyController difficultyController, SnakeCollectCoinController snakeCollectCoinController, IGameUI gameUI)
        {
            _difficultyController = difficultyController;
            _gameUI = gameUI;
            _snakeCollectCoinController = snakeCollectCoinController;
        }

        public void Initialize()
        {
            _snakeCollectCoinController.OnGameOver += HandleGameOver;
            _difficultyController.OnGameOver += HandleGameOver;
        }

        public void Dispose()
        {
            _snakeCollectCoinController.OnGameOver -= HandleGameOver;
            _difficultyController.OnGameOver -= HandleGameOver;
        }

        private void HandleGameOver(bool isWin)
        {
            _gameUI.GameOver(isWin);
            _snakeCollectCoinController.DeactivateSnake();
        }
    }
}