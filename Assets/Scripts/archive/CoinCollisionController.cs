// using Modules;
// using UnityEngine;
//
// namespace SnakeGame
// {
//     public class CoinCollisionController
//     {
//         private readonly CoinManager _coinManager;
//
//         public CoinCollisionController(CoinManager coinManager)
//         {
//             _coinManager = coinManager;
//         }
//
//         public Coin CheckCollision(Vector2Int position)
//         {
//             var spawnedCoins = _coinManager.GetSpawnedCoins();
//             for (int index = spawnedCoins.Count - 1; index >= 0; index--)
//             {
//                 var coin = spawnedCoins[index];
//                 if (coin != null && coin.Position == position)
//                 {
//                     return coin;
//                 }
//             }
//
//             return null;
//         }
//     }
// }