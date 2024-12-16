using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class SnakeDeactivationController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly GameCycle _gameCycle;

        public SnakeDeactivationController(ISnake snake, GameCycle gameCycle)
        {
            _snake = snake;
            _gameCycle = gameCycle;
        }

        public void Initialize()
        {
            _gameCycle.OnFinished += DeactivateSnake;
        }

        public void Dispose()
        {
            _gameCycle.OnFinished -= DeactivateSnake;
        }

        private void DeactivateSnake(bool _)
        {
            _snake.SetActive(false);
        }
    }
}