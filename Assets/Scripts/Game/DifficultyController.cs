using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class DifficultyController : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly CoinCollector _coinCollector;

        public DifficultyController(IDifficulty difficulty, CoinCollector coinCollector)
        {
            _difficulty = difficulty;
            _coinCollector = coinCollector;
        }

        public void Initialize()
        {
            ProgressDifficulty();
            _coinCollector.OnAllCoinCollected += ProgressDifficulty;
        }

        public void Dispose()
        {
            _coinCollector.OnAllCoinCollected -= ProgressDifficulty;
        }
        
        private void ProgressDifficulty()
        {
            _difficulty.Next(out _);
        }
    }
}