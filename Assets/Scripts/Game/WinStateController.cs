using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class WinStateController : IInitializable, IDisposable
    {
        private readonly CoinManager _coinManager;
        private readonly Difficulty _difficulty;
        private readonly GameCycle _gameCycle;

        public WinStateController(CoinManager coinManager, Difficulty difficulty, GameCycle gameCycle)
        {
            _coinManager = coinManager;
            _difficulty = difficulty;
            _gameCycle = gameCycle;
        }

        public void Initialize()
        {
            _coinManager.OnAllCoinCollected += CheckWinState;
        }

        public void Dispose()
        {
            _coinManager.OnAllCoinCollected -= CheckWinState;
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