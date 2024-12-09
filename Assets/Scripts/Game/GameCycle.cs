using System;
using UnityEngine;

namespace SnakeGame
{
    public class GameCycle
    {
        public event Action OnStarted;
        public event Action<bool> OnFinished;

        public void StartGame()
        {
            OnStarted?.Invoke();
        }

        public void WonGame()
        {
            OnFinished?.Invoke(true);
        }
        
        public void LooseGame()
        {
            OnFinished?.Invoke(false);
        }
    }
}