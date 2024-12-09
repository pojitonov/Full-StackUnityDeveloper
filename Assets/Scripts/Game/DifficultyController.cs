using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class DifficultyController : IInitializable, IDisposable
    {
        private readonly GameCycle _gameCycle;
        private readonly IDifficulty _difficulty;

        public DifficultyController(GameCycle gameCycle, IDifficulty difficulty)
        {
            _gameCycle = gameCycle;
            _difficulty = difficulty;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += OnDifficultyChanged;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }

        private void OnDifficultyChanged()
        {
            if (_difficulty.Current == _difficulty.Max)
            {
                _gameCycle.WonGame();
            }
        }
    }
}