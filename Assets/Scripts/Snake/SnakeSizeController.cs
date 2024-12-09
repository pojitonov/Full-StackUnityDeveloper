using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class SnakeSizeController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly CoinSpawner _coinSpawner;
        
        public SnakeSizeController(ISnake snake, CoinSpawner coinSpawner)
        {
            _snake = snake;
            _coinSpawner = coinSpawner;
        }

        public void Initialize()
        {
            _coinSpawner.OnCoinCollected += UpdateSize;
        }

        public void Dispose()
        {   
            _coinSpawner.OnCoinCollected -= UpdateSize;
        }
        
        private void UpdateSize(int bones)
        {
            _snake.Expand(bones);
        }
    }
}