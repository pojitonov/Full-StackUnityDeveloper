using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class SnakeSizeController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly CoinCollector _coinCollector;
        
        public SnakeSizeController(ISnake snake, CoinCollector coinCollector)
        {
            _snake = snake;
            _coinCollector = coinCollector;
        }

        public void Initialize()
        {
            _coinCollector.OnCoinCollected += UpdateSize;
        }

        public void Dispose()
        {   
            _coinCollector.OnCoinCollected -= UpdateSize;
        }
        
        private void UpdateSize(int bones)
        {
            _snake.Expand(bones);
        }
    }
}