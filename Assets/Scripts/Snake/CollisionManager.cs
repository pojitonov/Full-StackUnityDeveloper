using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class CollisionManager : IInitializable, IDisposable
    {
        public event Action<bool> OnGameOver;

        private readonly IWorldBounds _bounds;
        private readonly ISnake _snake;
        private readonly CoinCollector _coinCollector;

        public CollisionManager(IWorldBounds bounds, ISnake snake, CoinCollector coinCollector)
        {
            _bounds = bounds;
            _snake = snake;
            _coinCollector = coinCollector;
        }

        public void Initialize()
        {
            _snake.OnSelfCollided += HandleSelfCollision;
            _snake.OnMoved += HandleBoundsCollision;
            _snake.OnMoved += _coinCollector.CheckForCoinCollision;
        }

        public void Dispose()
        {
            _snake.OnSelfCollided -= HandleSelfCollision;
            _snake.OnMoved -= HandleBoundsCollision;
            _snake.OnMoved -= _coinCollector.CheckForCoinCollision;
        }

        private void HandleSelfCollision()
        {
            OnGameOver?.Invoke(false);
        }

        private void HandleBoundsCollision(Vector2Int position)
        {
            if (!_bounds.IsInBounds(position))
            {
                OnGameOver?.Invoke(false);
            }
        }
        
        public void DeactivateSnake()
        {
            _snake.SetActive(false);
        }
    }
}