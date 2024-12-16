using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class WinStateController : IInitializable, IDisposable
    {
        private readonly CoinCollector _coinCollector;
        private readonly CoinManager _coinManager;
        private readonly Difficulty _difficulty;
        private readonly GameCycle _gameCycle;

        public WinStateController(CoinCollector coinCollector, CoinManager coinManager, Difficulty difficulty, GameCycle gameCycle)
        {
            _coinCollector = coinCollector;
            _coinManager = coinManager;
            _difficulty = difficulty;
            _gameCycle = gameCycle;
        }

        public void Initialize()
        {
            _coinCollector.OnAllCoinCollected += CheckWinState;
        }

        public void Dispose()
        {
            _coinCollector.OnAllCoinCollected -= CheckWinState;
        }

        private void CheckWinState()
        {
            if (_difficulty.Current == _difficulty.Max && _coinManager.GetSpawnedCoins().Count == 0)
            {
                _gameCycle.Finish(true);
            }
        }
    }
}