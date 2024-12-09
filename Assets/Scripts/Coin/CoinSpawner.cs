using System;
using System.Collections.Generic;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class CoinSpawner : IDisposable, IInitializable
    {
        private readonly IWorldBounds _worldBounds;
        private readonly IDifficulty _difficulty;
        private readonly CoinFactory _coinFactory;
        private readonly CoinManager _coinManager;

        public CoinSpawner(IWorldBounds worldBounds, IDifficulty difficulty, CoinFactory coinFactory, CoinManager coinManager)
        {
            _worldBounds = worldBounds;
            _difficulty = difficulty;
            _coinFactory = coinFactory;
            _coinManager = coinManager;
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
                _coinManager.AddCoin(coin);
            }
        }
    }
}