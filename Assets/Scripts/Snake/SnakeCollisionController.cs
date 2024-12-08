using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class SnakeCollisionController : IInitializable, IDisposable
    {

        private readonly ISnake _snake;
        private readonly CoinCollector _coinCollector;

        public SnakeCollisionController(ISnake snake, CoinCollector coinCollector)
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