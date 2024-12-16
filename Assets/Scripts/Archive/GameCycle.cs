// using System;
// using Modules;
// using Zenject;
//
// namespace SnakeGame
// {
//     public class GameCycle : IInitializable, IDisposable
//     {
//         public event Action OnStarted;
//         public event Action<bool> OnFinished;
//
//         private readonly CoinCollector _coinCollector;
//         private readonly CoinManager _coinManager;
//         private readonly Difficulty _difficulty;
//
//         public GameCycle(CoinCollector coinCollector, CoinManager coinManager, Difficulty difficulty)
//         {
//             _coinCollector = coinCollector;
//             _coinManager = coinManager;
//             _difficulty = difficulty;
//         }
//
//         public void Initialize()
//         {
//             _coinCollector.OnAllCoinCollected += CheckWinState;
//         }
//
//         public void Dispose()
//         {
//             _coinCollector.OnAllCoinCollected -= CheckWinState;
//         }
//
//         public void Start()
//         {
//             OnStarted?.Invoke();
//         }
//
//         public void Finish(bool isWin)
//         {
//             OnFinished?.Invoke(isWin);
//         }
//
//         private void CheckWinState()
//         {
//             if (_difficulty.Current == _difficulty.Max && _coinManager.GetSpawnedCoins().Count == 0)
//             {
//                 Finish(true);
//             }
//         }
//     }
// }