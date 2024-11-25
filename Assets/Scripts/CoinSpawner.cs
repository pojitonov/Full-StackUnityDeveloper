using System.Collections.Generic;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class CoinSpawner : IInitializable
    {
        private readonly Coin _coinPrefab;
        private readonly WorldBounds _worldBounds;
        private const int numberOfCoins = 10;
        private readonly List<Coin> _spawnedCoins = new();

        public CoinSpawner(WorldBounds worldBounds, Coin coinPrefab)
        {
            _worldBounds = worldBounds;
            _coinPrefab = coinPrefab;
        }
        
        public void Initialize()
        {
            SpawnCoins();
        }

        private void SpawnCoins()
        {
            for (int i = 0; i < numberOfCoins; i++)
            {
                Vector2Int randomPosition = _worldBounds.GetRandomPosition();

                Coin coinObject = GameObject.Instantiate(_coinPrefab, (Vector2)randomPosition, Quaternion.identity);

                Coin coin = coinObject.GetComponent<Coin>();
                if (coin != null)
                {
                    coin.Position = randomPosition;
                    coin.Generate();
                    _spawnedCoins.Add(coin);
                }
                else
                {
                    Debug.LogError("The prefab does not have a Coin component attached.");
                }
            }
        }
    }
}