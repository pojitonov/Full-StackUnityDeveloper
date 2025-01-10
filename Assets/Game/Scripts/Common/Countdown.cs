using System;
using UnityEngine;

namespace Game.Scripts
{
    [Serializable]
    public class Countdown
    {
        public event Action OnTimeIsUp;

        [SerializeField]
        private float delayToDie;

        private float time;

        public bool IsTimeUp() => time <= 0;

        public void SetDuration(float duration)
        {
            delayToDie = duration;
            Reset();
        }

        public void Tick(float deltaTime)
        {
            if (time <= 0) return;

            time -= deltaTime;
            if (time <= 0)
            {
                OnTimeIsUp?.Invoke();
            }
        }

        public void Reset()
        {
            time = delayToDie;
            if (time <= 0)
            {
                OnTimeIsUp?.Invoke();
            }
        }
    }
}