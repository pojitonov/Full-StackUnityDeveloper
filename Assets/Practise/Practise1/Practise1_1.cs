using System;
using UnityEngine;

namespace Practise1
{
    /// Упражнение №1
    public sealed class ScoreManager
    {
        public int Score { get; private set; }

        public void AddScore(int amount)
        {
            this.Score += amount;
        }
    }

    public sealed class GameTimer : MonoBehaviour
    {
        [SerializeField]
        private float gameTimer;

        public event Action OnGameOver;

        private void Update()
        {
            this.gameTimer -= Time.deltaTime;
            if (this.gameTimer <= 0)
            {
                OnGameOver?.Invoke();
                Debug.Log("Game Over!");
                Time.timeScale = 0;
            }
        }
    }
}