using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class DeathSoundBehaviour : IEntityInit, IEntityDispose
    {
        private AudioSource _audioSource;
        private readonly AudioClip[] _clips;
        private IReactive<DamageArgs> _deathEvent;

        public DeathSoundBehaviour(AudioClip[] clips)
        {
            _clips = clips;
        }

        public void Init(in IEntity entity)
        {
            _audioSource = entity.GetAudioSource();
            _deathEvent = entity.GetDeathEvent();
            _deathEvent.Subscribe(OnDeath);
        }

        public void Dispose(in IEntity entity)
        {
            _deathEvent.Unsubscribe(OnDeath);
        }

        private void OnDeath(DamageArgs _)
        {
            if (_clips.Length == 0)
                return;

            int randomIndex = Random.Range(0, _clips.Length);
            AudioClip clip = _clips[randomIndex];
            _audioSource.PlayOneShot(clip);
        }
    }
}