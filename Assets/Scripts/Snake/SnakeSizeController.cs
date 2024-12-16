using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class SnakeSizeController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly CoinManager _coinManager;
        
        public SnakeSizeController(ISnake snake, CoinManager coinManager)
        {
            _snake = snake;
            _coinManager = coinManager;
        }

        public void Initialize()
        {
            _coinManager.OnCoinCollected += UpdateSize;
        }

        public void Dispose()
        {   
            _coinManager.OnCoinCollected -= UpdateSize;
        }
        
        private void UpdateSize(int bones)
        {
            _snake.Expand(bones);
        }
    }
}