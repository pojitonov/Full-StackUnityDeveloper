using System;
using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Gameplay
{
    public sealed class PainSoundBehaviour : IEntityInit, IEntityDispose
    {
        private Health _health;
        private IReactive<DamageArgs> _damageEvent;
        private AudioSource _audioSource;

        private readonly Level[] _damageLevels;

        public PainSoundBehaviour(Level[] damageLevels)
        {
            _damageLevels = damageLevels;
        }

        public void Init(in IEntity entity)
        {
            _health = entity.GetHealth();
            _audioSource = entity.GetAudioSource();
            _damageEvent = entity.GetTakeDamageEvent();
            _damageEvent.Subscribe(OnDamageTaken);
        }

        public void Dispose(in IEntity entity)
        {
            _damageEvent.Unsubscribe(OnDamageTaken);
        }

        private void OnDamageTaken(DamageArgs _)
        {
            this.PlaySound(_health.GetPercent());
        }

        private void PlaySound(float healthPercent)
        {
            for (int i = _damageLevels.Length - 1; i >= 0; i--)
            {
                Level level = _damageLevels[i];
                if (level.percent >= healthPercent)
                {
                    AudioClip damageSFX = level.RandomClip();
                    _audioSource.PlayOneShot(damageSFX);
                    return;
                }
            }
        }

        [Serializable]
        public struct Level
        {
            [SerializeField, Range(0.01f, 1.0f)]
            public float percent;

            [SerializeField]
            public AudioClip[] clips;

            public AudioClip RandomClip()
            {
                var index = Random.Range(0, this.clips.Length);
                return this.clips[index];
            }
        }
    }
}