using System;
using System.Collections.Generic;
using Modules;
using SnakeGame;

public class CoinManager
{
    public event Action<int> OnCoinCollected;
    public event Action OnAllCoinCollected;
    
    private List<Coin> SpawnedCoins { get; } = new();

    private readonly CoinsPool _coinsPool;

    public CoinManager(CoinsPool coinsPool)
    {
        _coinsPool = coinsPool;
    }

    public List<Coin> GetSpawnedCoins()
    {
        return SpawnedCoins;
    }

    public void AddCoin(Coin coin)
    {
        SpawnedCoins.Add(coin);
    }

    public void Collect(Coin coin)
    {
        var spawnedCoins = GetSpawnedCoins();
        _coinsPool.Despawn(coin);
        RemoveCoin(coin);

        OnCoinCollected?.Invoke(coin.Bones);
        if (spawnedCoins.Count == 0)
            OnAllCoinCollected?.Invoke();
    }

    private void RemoveCoin(Coin coin)
    {
        SpawnedCoins.Remove(coin);
    }
}