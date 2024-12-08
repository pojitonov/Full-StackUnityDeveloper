using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class SnakeSpeedController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IDifficulty _difficulty;

        public SnakeSpeedController(ISnake snake, IDifficulty difficulty)
        {
            _snake = snake;
            _difficulty = difficulty;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += UpdateSpeed;
        }

        public void Dispose()
        {   
            _difficulty.OnStateChanged -= UpdateSpeed;
        }

        private void UpdateSpeed()
        {
            _snake.SetSpeed(_difficulty.Current);
        }
    }
}