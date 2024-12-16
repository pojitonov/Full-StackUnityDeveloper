using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class ScoreController: IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly CoinManager _coinManager;

        public ScoreController(IScore score, CoinManager coinManager)
        {
            _score = score;
            _coinManager = coinManager;
        }

        public void Initialize()
        {
            _coinManager.OnCoinCollected += AddScore;
        }

        public void Dispose()
        {
            _coinManager.OnCoinCollected -= AddScore;
        }

        private void AddScore(int points)
        {
            _score.Add(points);
        }
    }
}