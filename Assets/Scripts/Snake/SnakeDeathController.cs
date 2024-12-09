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
        private readonly GameCycle _gameCycle;

        public SnakeDeathController(ISnake snake, IWorldBounds bounds, GameCycle gameCycle)
        {
            _snake = snake;
            _bounds = bounds;
            _gameCycle = gameCycle;
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

        private void HandleBoundsCollision(Vector2Int position)
        {
            if (!_bounds.IsInBounds(position))
            {
                HandleDeath();
            }
        }

        private void HandleSelfCollision()
        {
            HandleDeath();
        }

        private void HandleDeath()
        {
            _gameCycle.Finish(false);
        }
    }
}