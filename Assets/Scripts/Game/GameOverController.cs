using System;
using Zenject;

namespace SnakeGame
{
    public class GameOverController : IInitializable, IDisposable
    {
        private readonly DifficultyController _difficultyController;
        private readonly CollisionController _collisionController;
        private readonly IGameUI _gameUI;

        public GameOverController(DifficultyController difficultyController, CollisionController collisionController, IGameUI gameUI)
        {
            _difficultyController = difficultyController;
            _gameUI = gameUI;
            _collisionController = collisionController;
        }

        public void Initialize()
        {
            _collisionController.OnGameOver += HandleGameOver;
            _difficultyController.OnGameOver += HandleGameOver;
        }

        public void Dispose()
        {
            _collisionController.OnGameOver -= HandleGameOver;
            _difficultyController.OnGameOver -= HandleGameOver;
        }

        private void HandleGameOver(bool isWin)
        {
            _gameUI.GameOver(isWin);
            _collisionController.DeactivateSnake();
        }
    }
}