using System;
using UnityEngine;

namespace SnakeGame
{
    public class GameCycle
    {
        public event Action OnStarted;
        public event Action<bool> OnFinished;

        public void Start()
        {
            OnStarted?.Invoke();
        }

        public void Finish(bool isWin)
        {
            OnFinished?.Invoke(isWin);
        }
    }
}