using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class SnakeCoinCollectionController : IInitializable, IDisposable
    {

        private readonly ISnake _snake;
        private readonly CoinCollector _coinCollector;

        public SnakeCoinCollectionController(ISnake snake, CoinCollector coinCollector)
        {
            _snake = snake;
            _coinCollector = coinCollector;
        }

        public void Initialize()
        {
            _snake.OnMoved += _coinCollector.CheckForCoinCollision;
        }

        public void Dispose()
        {
            _snake.OnMoved -= _coinCollector.CheckForCoinCollision;
        }
    }
}