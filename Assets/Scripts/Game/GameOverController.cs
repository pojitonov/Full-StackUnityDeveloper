using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class GameOverController : IInitializable, IDisposable
    {
        private readonly DifficultyController _difficultyController;
        private readonly SnakeDeathController _snakeDeathController;
        private readonly IGameUI _gameUI;
        private readonly ISnake _snake;

        public GameOverController(DifficultyController difficultyController, IGameUI gameUI, SnakeDeathController snakeDeathController, ISnake snake)
        {
            _difficultyController = difficultyController;
            _gameUI = gameUI;
            _snakeDeathController = snakeDeathController;
            _snake = snake;
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
            _snake.SetActive(false);
        }
    }
}