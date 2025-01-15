using System;
using UnityEngine;

namespace Game.Scripts.Common
{
    [Serializable]
    public class Countdown
    {
        public event Action OnTimeIsUp;

        [SerializeField] 
        private float _duration;
        
        private float time;

        public bool IsTimeUp() => time <= 0;

        public void SetDuration(float duration)
        {
            _duration = duration;
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
            time = _duration;
            if (time <= 0)
            {
                OnTimeIsUp?.Invoke();
            }
        }
    }
}