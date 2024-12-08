using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class SnakeDeathController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IWorldBounds _bounds;

        public event Action<bool> OnGameOver;

        public SnakeDeathController(ISnake snake, IWorldBounds bounds)
        {
            _snake = snake;
            _bounds = bounds;
        }

        public void Initialize()
        {
            _snake.OnSelfCollided += HandleSelfCollision;
            _snake.OnMoved += HandleBoundsCollision;
        }

        public void Dispose()
        {
            _snake.OnSelfCollided -= HandleSelfCollision;
            _snake.OnMoved -= HandleBoundsCollision;
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
    }
}