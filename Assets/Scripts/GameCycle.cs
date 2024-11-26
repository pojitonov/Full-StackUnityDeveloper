using System;
using System.Collections.Generic;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class GameCycle : IInitializable, IDisposable
    {
        private List<Coin> _spawnedCoins;
        
        private readonly ISnake _snake;
        private readonly IScore _score;
        private readonly IGameUI _gameUI;
        private readonly CoinController _coinController;

        public GameCycle(ISnake snake, IScore score, IGameUI gameUI, CoinController coinController)
        {
            _snake = snake;
            _score = score;
            _gameUI = gameUI;
            _coinController = coinController;
        }

        public void Initialize()
        {
            _spawnedCoins = _coinController.GetCoins();
            _snake.OnMoved += CheckForCoinCollision;
            _score.OnStateChanged += OnScoreChanged;
            GameStart();
        }

        public void Dispose()
        {
            _score.OnStateChanged -= OnScoreChanged;
            _snake.OnMoved -= CheckForCoinCollision;

        }

        private void GameStart()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            _gameUI.SetScore(_score.Current.ToString());
        }

        private void OnScoreChanged(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
        
        private void CheckForCoinCollision(Vector2Int position)
        {
            for (int index = _spawnedCoins.Count - 1; index >= 0; index--)
            {
                var coin = _spawnedCoins[index];
                if (coin != null && coin.Position == position)
                {
                    CollectCoin(coin, index);
                }
            }
        }

        private void CollectCoin(Coin coin, int index)
        {
            _coinController.CollectCoins(coin);
            _spawnedCoins.RemoveAt(index);
            _score.Add(coin.Score);
        }
    }
}