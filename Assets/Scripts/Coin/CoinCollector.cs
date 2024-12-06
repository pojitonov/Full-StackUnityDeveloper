using System;
using Modules;
using UnityEngine;

namespace SnakeGame
{
    public class CoinCollector
    {
        public event Action<int> OnCoinCollected;

        private readonly IScore _score;
        private readonly IDifficulty _difficulty;
        private readonly CoinFactory _factory;

        public CoinCollector(IScore score, IDifficulty difficulty, CoinFactory factory)
        {
            _score = score;
            _difficulty = difficulty;
            _factory = factory;
        }

        public void CheckForCoinCollision(Vector2Int position)
        {
            for (int index = _factory.SpawnedCoins.Count - 1; index >= 0; index--)
            {
                var coin = _factory.SpawnedCoins[index];
                if (coin != null && coin.Position == position)
                {
                    Collect(coin);
                }
            }
        }

        private void Collect(Coin coin)
        {
            _factory.SpawnedCoins.Remove(coin);
            GameObject.Destroy(coin.gameObject);
            _score.Add(coin.Score);
            if (_factory.SpawnedCoins.Count == 0)
                _difficulty.Next(out _);
            OnCoinCollected?.Invoke(coin.Bones);
        }
    }
}