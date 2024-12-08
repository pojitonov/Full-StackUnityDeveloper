using System;
using Zenject;

namespace SnakeGame
{
    public class GameOverController : IInitializable, IDisposable
    {
        private readonly DifficultyController _difficultyController;
        private readonly SnakeDeathController _snakeDeathController;
        private readonly SnakeCollisionController _snakeCollisionController;
        private readonly IGameUI _gameUI;

        public GameOverController(DifficultyController difficultyController, IGameUI gameUI, SnakeDeathController snakeDeathController, SnakeCollisionController snakeCollisionController)
        {
            _difficultyController = difficultyController;
            _gameUI = gameUI;
            _snakeDeathController = snakeDeathController;
            _snakeCollisionController = snakeCollisionController;
        }

        public void Initialize()
        {
            _snakeDeathController.OnGameOver += HandleGameOver;
            _difficultyController.OnGameOver += HandleGameOver;
        }

        public void Dispose()
        {
            _snakeDeathController.OnGameOver -= HandleGameOver;
            _difficultyController.OnGameOver -= HandleGameOver;
        }

        private void HandleGameOver(bool isWin)
        {
            _gameUI.GameOver(isWin);
            _snakeCollisionController.DeactivateSnake();
        }
    }
}