using System;
using System.Collections.Generic;
using Modules;
using UnityEngine;

namespace SnakeGame
{
    public class CoinCollector
    {
        public event Action<int> OnCoinCollected;

        private readonly ScoreController _scoreController;
        private readonly DifficultyController _difficultyController;
        private readonly CoinManager _coinManager;

        public CoinCollector(ScoreController scoreController, DifficultyController difficultyController, CoinManager coinManager)
        {
            _scoreController = scoreController;
            _difficultyController = difficultyController;
            _coinManager = coinManager;
        }

        public void Collect(Coin coin)
        {
            var spawnedCoins = _coinManager.GetSpawnedCoins();
            spawnedCoins.Remove(coin);
            GameObject.Destroy(coin.gameObject);
            
            _scoreController.AddScore(coin.Score);
            
            if (spawnedCoins.Count == 0)
                _difficultyController.ProgressDifficulty();
            
            OnCoinCollected?.Invoke(coin.Bones);
        }
    }
}