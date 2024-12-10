using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class UIDifficultyController : IInitializable, IDisposable
    {
        private readonly GameCycle _gameCycle;
        private readonly IGameUI _gameUI;
        private readonly IDifficulty _difficulty;

        public UIDifficultyController(GameCycle gameCycle, IGameUI gameUI, IDifficulty difficulty)
        {
            _gameCycle = gameCycle;
            _gameUI = gameUI;
            _difficulty = difficulty;
        }
        
        public void Initialize()
        {
            _gameCycle.OnStarted += UpdateUI;
            _difficulty.OnStateChanged += UpdateUI;
        }

        public void Dispose()
        {
            _gameCycle.OnStarted -= UpdateUI;
            _difficulty.OnStateChanged -= UpdateUI;
        }

        private void UpdateUI()
        {
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
        }
    }
}