using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class GameOverController : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly ISnake _snake;
        private readonly GameCycle _gameCycle;

        public GameOverController(GameCycle gameCycle, IGameUI gameUI, ISnake snake)
        {
            _gameCycle = gameCycle;
            _gameUI = gameUI;
            _snake = snake;
        }

        public void Initialize()
        {
            _gameCycle.OnFinished += HandleGameOver;
        }
        
        public void Dispose()
        {
            _gameCycle.OnFinished += HandleGameOver;
        }

        private void HandleGameOver(bool isWin)
        {
            _gameUI.GameOver(isWin);
            _snake.SetActive(false);
        }
    }
}