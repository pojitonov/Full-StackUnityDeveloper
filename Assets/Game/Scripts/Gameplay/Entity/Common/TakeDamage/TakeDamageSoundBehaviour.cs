using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class TakeDamageSoundBehaviour : IEntityInit, IEntityDispose
    {
        private AudioSource _audioSource;
        private readonly AudioClip[] audioClips;
        private readonly List<AudioClip> availableClips = new();
        private IReactive<int> _damageEvent;

        public TakeDamageSoundBehaviour(AudioClip[] audioClips)
        {
            this.audioClips = audioClips;
        }

        public void Init(in IEntity entity)
        {
            _audioSource = entity.GetAudioSource();
            _damageEvent = entity.GetTakeDamageEvent();

            _damageEvent.Subscribe(OnDamageTaken);
        }

        public void Dispose(in IEntity entity)
        {
            _damageEvent.Unsubscribe(OnDamageTaken);
        }

        private void OnDamageTaken(int _)
        {
            if (this.availableClips.Count == 0)
                this.availableClips.AddRange(audioClips);

            int randomIndex = Random.Range(0, availableClips.Count);
            AudioClip targetClip = availableClips[randomIndex];
            availableClips.Remove(targetClip);

            _audioSource.PlayOneShot(targetClip);
        }
    }
}