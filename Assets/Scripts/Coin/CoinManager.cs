using System.Collections.Generic;
using Modules;

public class CoinManager
{
    private List<Coin> SpawnedCoins { get; } = new();

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