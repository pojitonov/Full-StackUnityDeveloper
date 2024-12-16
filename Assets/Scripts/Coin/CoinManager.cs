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

    public CoinManager(CoinsPool coinsPool)
    {
        _coinsPool = coinsPool;
    }

    public void AddCoin(Coin coin)
    {
        SpawnedCoins.Add(coin);
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
}