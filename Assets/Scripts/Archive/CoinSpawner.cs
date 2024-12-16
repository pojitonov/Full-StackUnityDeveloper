// using System;
// using Modules;
// using UnityEngine;
// using Zenject;
//
// namespace SnakeGame
// {
//     public class CoinSpawner : IDisposable, IInitializable
//     {
//         private readonly IWorldBounds _worldBounds;
//         private readonly IDifficulty _difficulty;
//         private readonly CoinManager _coinManager;
//         private readonly CoinsPool _coinsPool;
//
//         public CoinSpawner(IWorldBounds worldBounds, IDifficulty difficulty, CoinManager coinManager, CoinsPool coinsPool)
//         {
//             _worldBounds = worldBounds;
//             _difficulty = difficulty;
//             _coinManager = coinManager;
//             _coinsPool = coinsPool;
//         }
//
//         public void Initialize()
//         {
//             SpawnCoins();
//             _difficulty.OnStateChanged += SpawnCoins;
//         }
//
//         public void Dispose()
//         {
//             _difficulty.OnStateChanged -= SpawnCoins;
//         }
//
//         private void SpawnCoins()
//         {
//             int coinCount = _difficulty.Current;
//
//             for (int i = 0; i < coinCount; i++)
//             {
//                 Vector2Int randomPosition = _worldBounds.GetRandomPosition();
//                 Coin coin = _coinsPool.Spawn();
//                 coin.transform.SetPositionAndRotation((Vector2)randomPosition, Quaternion.identity);
//                 coin.Generate();
//                 _coinManager.AddCoin(coin);
//             }
//         }
//     }
// }