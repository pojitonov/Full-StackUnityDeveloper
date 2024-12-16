using System;
using Zenject;

namespace SnakeGame
{
    public class UIGameOverController : IInitializable, IDisposable
    {
        private readonly GameCycle _gameCycle;
        private readonly IGameUI _gameUI;

        public UIGameOverController(GameCycle gameCycle, IGameUI gameUI)
        {
            _gameCycle = gameCycle;
            _gameUI = gameUI;
        }
        
        public void Initialize()
        {
            _gameCycle.OnFinished += UpdateUI;
        }
        
        public void Dispose()
        {
            _gameCycle.OnFinished -= UpdateUI;
        }

        private void UpdateUI(bool isWIn)
        {
            _gameUI.GameOver(isWIn);
        }
    }
}