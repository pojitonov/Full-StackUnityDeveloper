using System;
using System.Collections.Generic;
using Modules;
using SnakeGame;

public class CoinManager
{
    public event Action<int> OnCoinCollected;
    public event Action OnAllCoinCollected;
    
    private List<Coin> SpawnedCoins { get; } = new();

    private readonly ScoreController _scoreController;
    private readonly CoinsPool _coinsPool;

    public CoinManager(ScoreController scoreController, CoinsPool coinsPool)
    {
        _scoreController = scoreController;
        _coinsPool = coinsPool;
    }

    public void Collect(Coin coin)
    {
        var spawnedCoins = GetSpawnedCoins();
        _coinsPool.Despawn(coin);
        RemoveCoin(coin);
        _scoreController.AddScore(coin.Score);

        OnCoinCollected?.Invoke(coin.Bones);
        if (spawnedCoins.Count == 0)
            OnAllCoinCollected?.Invoke();
    }

    public void AddCoin(Coin coin)
    {
        SpawnedCoins.Add(coin);
    }

    public void RemoveCoin(Coin coin)
    {
        SpawnedCoins.Remove(coin);
    }
    
    public List<Coin> GetSpawnedCoins()
    {
        return SpawnedCoins;
    }
}