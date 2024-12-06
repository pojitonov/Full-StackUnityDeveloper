using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class SnakeManager : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IDifficulty _difficulty;
        private readonly CoinCollector _coinCollector;

        public SnakeManager(ISnake snake, IDifficulty difficulty, CoinCollector coinCollector)
        {
            _snake = snake;
            _difficulty = difficulty;
            _coinCollector = coinCollector;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += UpdateSpeed;
            _coinCollector.OnCoinCollected += UpdateSize;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= UpdateSpeed;
            _coinCollector.OnCoinCollected -= UpdateSize;
        }

        private void UpdateSize(int bones)
        {
            _snake.Expand(bones);
        }

        private void UpdateSpeed()
        {
            _snake.SetSpeed(_difficulty.Current);
        }
    }
}