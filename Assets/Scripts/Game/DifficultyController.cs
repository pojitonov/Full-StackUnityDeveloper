using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class DifficultyController : IInitializable, IDisposable
    {
        private readonly GameCycle _gameCycle;
        private readonly IGameUI _gameUI;
        private readonly IDifficulty _difficulty;

        public DifficultyController(GameCycle gameCycle, IGameUI gameUI, IDifficulty difficulty)
        {
            _gameCycle = gameCycle;
            _gameUI = gameUI;
            _difficulty = difficulty;
        }

        public void Initialize()
        {
            _gameCycle.OnStarted += UpdateUI;
            _difficulty.OnStateChanged += OnDifficultyChanged;
        }

        public void Dispose()
        {
            _gameCycle.OnStarted -= UpdateUI;
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }

        private void OnDifficultyChanged()
        {
            UpdateUI();
            if (_difficulty.Current == _difficulty.Max)
            {
                _gameCycle.WonGame();
            }
        }

        private void UpdateUI()
        {
            _gameUI.SetDifficulty(_difficulty.Current + 1, _difficulty.Max);
        }
    }
}