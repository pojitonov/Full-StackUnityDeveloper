using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class SnakeCollectionController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly CoinManager _coinManager;

        public SnakeCollectionController(ISnake snake, CoinManager coinManager)
        {
            _snake = snake;
            _coinManager = coinManager;
        }

        public void Initialize()
        {
            _snake.OnMoved += HandleSnakeMovement;
        }

        public void Dispose()
        {
            _snake.OnMoved -= HandleSnakeMovement;
        }

        private void HandleSnakeMovement(Vector2Int position)
        {
            var coin = _coinManager.CheckCollision(position);
            if (coin != null)
            {
                _coinManager.Collect(coin);
            }
        }
    }
}