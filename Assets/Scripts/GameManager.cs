using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class GameManager : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly IDifficulty _difficulty;
        private readonly IGameUI _gameUI;

        public GameManager(IScore score, IDifficulty difficulty, IGameUI gameUI)
        {
            _score = score;
            _difficulty = difficulty;
            _gameUI = gameUI;
        }

        public void Initialize()
        {
            _score.OnStateChanged += OnScoreChanged;
            _difficulty.OnStateChanged += OnDifficultyChanged;
            GameStart();
        }

        public void Dispose()
        {
            _score.OnStateChanged -= OnScoreChanged;
            _difficulty.OnStateChanged -= OnDifficultyChanged;

        }

        private void GameStart()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            _gameUI.SetScore(_score.Current.ToString());
            _gameUI.SetDifficulty(_difficulty.Current + 1, _difficulty.Max);
        }

        private void OnDifficultyChanged()
        {
            _gameUI.SetDifficulty(_difficulty.Current + 1, _difficulty.Max);
        }
        
        private void OnScoreChanged(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
    }
}