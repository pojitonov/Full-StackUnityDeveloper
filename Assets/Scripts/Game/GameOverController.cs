using System;
using Zenject;

namespace SnakeGame
{
    public class GameOverController : IInitializable, IDisposable
    {
        private readonly DifficultyController _difficultyController;
        private readonly CollisionManager _collisionManager;
        private readonly IGameUI _gameUI;

        public GameOverController(DifficultyController difficultyController, CollisionManager collisionManager, IGameUI gameUI)
        {
            _difficultyController = difficultyController;
            _gameUI = gameUI;
            _collisionManager = collisionManager;
        }

        public void Initialize()
        {
            _collisionManager.OnGameOver += HandleGameOver;
            _difficultyController.OnGameOver += HandleGameOver;
        }

        public void Dispose()
        {
            _collisionManager.OnGameOver -= HandleGameOver;
            _difficultyController.OnGameOver -= HandleGameOver;
        }

        private void HandleGameOver(bool isWin)
        {
            _gameUI.GameOver(isWin);
            _collisionManager.DeactivateSnake();
        }
    }
}