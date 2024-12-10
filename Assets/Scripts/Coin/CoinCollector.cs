using System;
using Modules;
using UnityEngine;

namespace SnakeGame
{
    public class CoinCollector
    {
        public event Action<int> OnCoinCollected;
        public event Action OnAllCoinCollected;

        private readonly ScoreController _scoreController;
        private readonly CoinManager _coinManager;

        public CoinCollector(ScoreController scoreController, CoinManager coinManager)
        {
            _scoreController = scoreController;
            _coinManager = coinManager;
        }

        public void Collect(Coin coin)
        {
            var spawnedCoins = _coinManager.GetSpawnedCoins();
            GameObject.Destroy(coin.gameObject);
            _coinManager.RemoveCoin(coin);
            _scoreController.AddScore(coin.Score);

            OnCoinCollected?.Invoke(coin.Bones);
            if (spawnedCoins.Count == 0)
                OnAllCoinCollected?.Invoke();
        }
    }
}