using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class SnakeManager : IInitializable, IDisposable
    {
        public event Action<bool> OnGameOver;
        
        private readonly ISnake _snake;
        private readonly IDifficulty _difficulty;
        private readonly CoinManager _coinManager;
        private readonly IWorldBounds _worldBounds;

        public SnakeManager(ISnake snake, IDifficulty difficulty, CoinManager coinManager, IWorldBounds worldBounds)
        {
            _snake = snake;
            _difficulty = difficulty;
            _coinManager = coinManager;
            _worldBounds = worldBounds;
        }

        public void Initialize()
        {
            _snake.OnSelfCollided += HandleSelfCollision;
            _snake.OnMoved += HandleOutOfBounds;
            _snake.OnMoved += _coinManager.CheckForCoinCollision;
            _difficulty.OnStateChanged += UpdateSpeed;
            _coinManager.OnCoinCollected += UpdateSize;
        }

        public void Dispose()
        {
            _snake.OnSelfCollided -= HandleSelfCollision;
            _snake.OnMoved -= HandleOutOfBounds;
            _snake.OnMoved -= _coinManager.CheckForCoinCollision;
            _difficulty.OnStateChanged -= UpdateSpeed;
            _coinManager.OnCoinCollected -= UpdateSize;
        }
        
        private void HandleSelfCollision()
        {
            OnGameOver?.Invoke(false);
        }

        private void HandleOutOfBounds(Vector2Int position)
        {
           if(!_worldBounds.IsInBounds(position))
           {
               OnGameOver?.Invoke(false);
           }
        }

        private void UpdateSize(int bones)
        {
            _snake.Expand(bones);
        }

        private void UpdateSpeed()
        {
            _snake.SetSpeed(_difficulty.Current);
        }
    }
}