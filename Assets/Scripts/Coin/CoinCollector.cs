using System;
using Modules;

namespace SnakeGame
{
    public class CoinCollector
    {
        public event Action<int> OnCoinCollected;
        public event Action OnAllCoinCollected;

        private readonly ScoreController _scoreController;
        private readonly CoinManager _coinManager;
        private readonly CoinsPool _coinsPool;

        public CoinCollector(ScoreController scoreController, CoinManager coinManager, CoinsPool coinsPool)
        {
            _scoreController = scoreController;
            _coinManager = coinManager;
            _coinsPool = coinsPool;
        }

        public void Collect(Coin coin)
        {
            var spawnedCoins = _coinManager.GetSpawnedCoins();
            _coinsPool.Despawn(coin);
            _coinManager.RemoveCoin(coin);
            _scoreController.AddScore(coin.Score);

            OnCoinCollected?.Invoke(coin.Bones);
            if (spawnedCoins.Count == 0)
                OnAllCoinCollected?.Invoke();
        }
    }
}