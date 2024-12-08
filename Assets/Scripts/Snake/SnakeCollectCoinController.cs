using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class SnakeCollectCoinController : IInitializable, IDisposable
    {
        public event Action<bool> OnGameOver;

        private readonly ISnake _snake;
        private readonly CoinCollector _coinCollector;

        public SnakeCollectCoinController(ISnake snake, CoinCollector coinCollector)
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
        
        public void DeactivateSnake()
        {
            _snake.SetActive(false);
        }
    }
}