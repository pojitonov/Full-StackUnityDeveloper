using System;
using System.Collections.Generic;
using Modules;
using SnakeGame;
using UnityEngine;

public class CoinManager
{
    public event Action<int> OnCoinCollected;
    public event Action OnAllCoinCollected;

    public List<Coin> SpawnedCoins { get; } = new();
    private readonly CoinsPool _coinsPool;
    private readonly IWorldBounds _worldBounds;
    private readonly IDifficulty _difficulty;

    public CoinManager(CoinsPool coinsPool, IWorldBounds worldBounds, IDifficulty difficulty)
    {
        _coinsPool = coinsPool;
        _worldBounds = worldBounds;
        _difficulty = difficulty;
    }

    public void Collect(Coin coin)
    {
        _coinsPool.Despawn(coin);
        SpawnedCoins.Remove(coin);

        OnCoinCollected?.Invoke(coin.Bones);
        if (SpawnedCoins.Count == 0)
            OnAllCoinCollected?.Invoke();
    }

    public Coin CheckCollision(Vector2Int position)
    {
        for (int index = SpawnedCoins.Count - 1; index >= 0; index--)
        {
            var coin = SpawnedCoins[index];
            if (coin != null && coin.Position == position)
            {
                return coin;
            }
        }

        return null;
    }

    public void SpawnCoins()
    {
        int coinCount = _difficulty.Current;

        for (int i = 0; i < coinCount; i++)
        {
            Vector2Int randomPosition = _worldBounds.GetRandomPosition();
            Coin coin = _coinsPool.Spawn();
            coin.transform.SetPositionAndRotation((Vector2)randomPosition, Quaternion.identity);
            coin.Generate();
            AddCoin(coin);
        }
    }

    private void AddCoin(Coin coin)
    {
        SpawnedCoins.Add(coin);
    }
}