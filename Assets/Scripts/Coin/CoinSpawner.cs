using System;
using System.Collections.Generic;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class CoinSpawner : IDisposable, IInitializable
    {
        private readonly Coin _coinPrefab;
        private readonly IWorldBounds _worldBounds;
        private readonly IDifficulty _difficulty;
        private readonly CoinFactory _coinFactory ;
        public List<Coin> SpawnedCoins { get; } = new();
        
        public CoinSpawner(Coin coinPrefab, IWorldBounds worldBounds, IDifficulty difficulty, CoinFactory coinFactory)
        {
            _coinPrefab = coinPrefab;
            _worldBounds = worldBounds;
            _difficulty = difficulty;
            _coinFactory = coinFactory;
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
    }
}