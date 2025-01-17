using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Core
{
    [Serializable]
    public class Cooldown
    {
        public event Action OnTimeIsUp;

        [SerializeField] 
        private float _duration;
        
        [SerializeField, ReadOnly] 
        private float elapsedTime;

        public bool IsTimeUp() => elapsedTime <= 0;

        public void SetDuration(float duration)
        {
            _duration = duration;
            Reset();
        }

        public void Tick(float deltaTime)
        {
            if (elapsedTime <= 0) return;

            elapsedTime -= deltaTime;
            if (elapsedTime <= 0)
            {
                OnTimeIsUp?.Invoke();
            }
        }

        public void Reset()
        {
            elapsedTime = _duration;
            if (elapsedTime <= 0)
            {
                OnTimeIsUp?.Invoke();
            }
        }
    }
}