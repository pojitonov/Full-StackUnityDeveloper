using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class UnitTakeDamageAudioSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<UnitTag> _tag;
        private readonly EcsEventInject<TakeDamageEvent> _events;
        private readonly EcsPoolInject<AudioSourceView> _audioSource;
        private readonly AudioClip _audioClip;

        public UnitTakeDamageAudioSystem(AudioClip audioClip)
        {
            _audioClip = audioClip;
        }
        
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (TakeDamageEvent damageEvent in _events.Value)
            {
                if (!damageEvent.target.Unpack(_world.Value, out int target))
                    continue;

                if (!_tag.Value.Has(target))
                    continue;

                if (!_audioSource.Value.Has(target))
                    continue;
                
                AudioSource audio = _audioSource.Value.Get(target).value;
                audio.clip = _audioClip;
                audio.Play();
            }
        }
    }
}