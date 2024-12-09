using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class UIScoreController : IInitializable, IDisposable
    {
        private readonly GameCycle _gameCycle;
        private readonly IGameUI _gameUI;
        private readonly IScore _score;

        public UIScoreController(GameCycle gameCycle, IGameUI gameUI, IScore score)
        {
            _gameCycle = gameCycle;
            _gameUI = gameUI;
            _score = score;
        }
        
        public void Initialize()
        {
            _gameCycle.OnStarted += UpdateUI;
            _score.OnStateChanged += OnScoreChanged;
        }
        
        public void Dispose()
        {
            _gameCycle.OnStarted -= UpdateUI;
            _score.OnStateChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int _)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            _gameUI.SetScore(_score.Current.ToString());
        }
    }
}