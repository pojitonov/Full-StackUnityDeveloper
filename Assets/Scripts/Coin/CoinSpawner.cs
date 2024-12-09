using System;
using System.Collections.Generic;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class CoinSpawner : IDisposable, IInitializable
    {
        public event Action<int> OnCoinCollected;

        private readonly IWorldBounds _worldBounds;
        private readonly IDifficulty _difficulty;
        private readonly IScore _score;
        private readonly Factory _coinFactory;
        private List<Coin> SpawnedCoins { get; } = new();

        public CoinSpawner(IWorldBounds worldBounds, IDifficulty difficulty, IScore score, Factory coinFactory)
        {
            _worldBounds = worldBounds;
            _difficulty = difficulty;
            _coinFactory = coinFactory;
            _score = score;
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

        private void SpawnCoins()
        {
            int coinCount = _difficulty.Current + 1;

            for (int i = 0; i < coinCount; i++)
            {
                Vector2Int randomPosition = _worldBounds.GetRandomPosition();
                Coin coin = _coinFactory.Create();
                coin.transform.SetPositionAndRotation((Vector2)randomPosition, Quaternion.identity);
                coin.Generate();
                SpawnedCoins.Add(coin);
            }
        }
        
        public void CheckForCoinCollision(Vector2Int position)
        {
            for (int index = SpawnedCoins.Count - 1; index >= 0; index--)
            {
                var coin = SpawnedCoins[index];
                if (coin != null && coin.Position == position)
                {
                    Collect(coin);
                }
            }
        }

        private void Collect(Coin coin)
        {
            SpawnedCoins.Remove(coin);
            GameObject.Destroy(coin.gameObject);
            _score.Add(coin.Score);
            if (SpawnedCoins.Count == 0)
                _difficulty.Next(out _);
            OnCoinCollected?.Invoke(coin.Bones);
        }
    }

    public sealed class Factory : PlaceholderFactory<Coin>
    {
    }
}