using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class SnakeCollectionController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly CoinCollisionController _coinCollisionController;
        private readonly CoinCollector _coinCollector;

        public SnakeCollectionController(ISnake snake, CoinCollisionController coinCollisionController, CoinCollector coinCollector)
        {
            _snake = snake;
            _coinCollisionController = coinCollisionController;
            _coinCollector = coinCollector;
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
            var coin = _coinCollisionController.CheckCollision(position);
            if (coin != null)
            {
                _coinCollector.Collect(coin);
            }
        }
    }
}