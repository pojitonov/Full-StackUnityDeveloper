using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class CoinSpawnController : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly CoinManager _coinManager;

        public CoinSpawnController(IDifficulty difficulty, CoinManager coinManager)
        {
            _difficulty = difficulty;
            _coinManager = coinManager;
        }

        public void Initialize()
        {
            _coinManager.SpawnCoins();
            _difficulty.OnStateChanged += _coinManager.SpawnCoins;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= _coinManager.SpawnCoins;
        }
    }
}