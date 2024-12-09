using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class SnakeCoinCollectionController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly CoinSpawner _coinSpawner;

        public SnakeCoinCollectionController(ISnake snake, CoinSpawner coinSpawner)
        {
            _snake = snake;
            _coinSpawner = coinSpawner;
        }

        public void Initialize()
        {
            _snake.OnMoved += _coinSpawner.CheckForCoinCollision;
        }

        public void Dispose()
        {
            _snake.OnMoved -= _coinSpawner.CheckForCoinCollision;
        }
    }
}