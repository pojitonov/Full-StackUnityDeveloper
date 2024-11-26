using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class SnakeManager : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IDifficulty _difficulty;
        private readonly CoinManager _coinManager;

        public SnakeManager(ISnake snake, IDifficulty difficulty, CoinManager coinManager)
        {
            _snake = snake;
            _difficulty = difficulty;
            _coinManager = coinManager;
        }

        public void Initialize()
        {
            _snake.OnMoved += _coinManager.CheckForCoinCollision;
            _difficulty.OnStateChanged += UpdateSpeed;
            _coinManager.OnCoinCollected += UpdateSize;
        }

        public void Dispose()
        {
            _snake.OnMoved -= _coinManager.CheckForCoinCollision;
            _difficulty.OnStateChanged -= UpdateSpeed;
            _coinManager.OnCoinCollected -= UpdateSize;
        }

        private void UpdateSize()
        {
            _snake.Expand(1);
        }

        private void UpdateSpeed()
        {
            _snake.SetSpeed(_difficulty.Current);
        }
    }
}