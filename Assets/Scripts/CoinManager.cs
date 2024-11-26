using System;
using System.Collections.Generic;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class CoinManager : IInitializable, IDisposable
    {
        public event Action<int> OnCoinCollected;

        private readonly List<Coin> _spawnedCoins = new();

        private readonly Coin _coinPrefab;
        private readonly IWorldBounds _worldBounds;
        private readonly IScore _score;
        private readonly IDifficulty _difficulty;

        public CoinManager(Coin coinPrefab, IWorldBounds worldBounds, IScore score, IDifficulty difficulty)
        {
            _coinPrefab = coinPrefab;
            _worldBounds = worldBounds;
            _score = score;
            _difficulty = difficulty;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += SpawnCoins;
            SpawnCoins();
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= SpawnCoins;
        }

        public void CheckForCoinCollision(Vector2Int position)
        {
            for (int index = _spawnedCoins.Count - 1; index >= 0; index--)
            {
                var coin = _spawnedCoins[index];
                if (coin != null && coin.Position == position)
                {
                    CollectCoin(coin);
                }
            }
        }

        private void SpawnCoins()
        {
            int coinCount = _difficulty.Current + 1;

            for (int i = 0; i < coinCount; i++)
            {
                Vector2Int randomPosition = _worldBounds.GetRandomPosition();
                Coin coinObject = GameObject.Instantiate(_coinPrefab, (Vector2)randomPosition, Quaternion.identity);
                Coin coin = coinObject.GetComponent<Coin>();
                coin.Position = randomPosition;
                coin.Generate();
                _spawnedCoins.Add(coin);
            }
        }

        private void CollectCoin(Coin coin)
        {
            _spawnedCoins.Remove(coin);
            GameObject.Destroy(coin.gameObject);
            _score.Add(coin.Score);
            if (_spawnedCoins.Count == 0)
                _difficulty.Next(out _);
            OnCoinCollected?.Invoke(coin.Bones);
        }
    }
}