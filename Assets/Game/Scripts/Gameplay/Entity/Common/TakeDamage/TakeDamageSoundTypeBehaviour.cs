using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class TakeDamageSoundTypeBehaviour : IEntityInit, IEntityDispose
    {
        private readonly AudioClip _meleeSFX;
        private readonly AudioClip _bulletSFX;
        
        private IReactive<DamageArgs> _damageEvent;
        private IReactive<DamageArgs> _deathEvent;
        private AudioSource _audioSource;

        public TakeDamageSoundTypeBehaviour(AudioClip meleeSfx, AudioClip bulletSfx)
        {
            _meleeSFX = meleeSfx;
            _bulletSFX = bulletSfx;
        }
        
        public void Init(in IEntity entity)
        {
            _audioSource = entity.GetAudioSource();
            _damageEvent = entity.GetTakeDamageEvent();
            _deathEvent = entity.GetDeathEvent();
            _damageEvent.Subscribe(this.OnDamageTaken);
            _deathEvent.Subscribe(this.OnDamageTaken);
        }

        public void Dispose(in IEntity entity)
        {
            _damageEvent.Unsubscribe(this.OnDamageTaken);
            _deathEvent.Unsubscribe(this.OnDamageTaken);
        }

        private void OnDamageTaken(DamageArgs args)
        {
            IEntity source = args.source;
            if (source == null)
                return;

            if (source.HasEnemyTag())
                _audioSource.PlayOneShot(_meleeSFX);
            else if (!source.HasEnemyTag()) 
                _audioSource.PlayOneShot(_bulletSFX);
        }
    }
}