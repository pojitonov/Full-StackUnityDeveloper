using Atomic.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Gameplay
{
    public sealed class CharacterAudioInstaller : SceneEntityInstaller
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private PainSoundBehaviour.Level[] _painLevels;
        [SerializeField] private AudioClip[] _deathClips;
        [SerializeField] private AudioClip[] _moveStepClips;
        [SerializeField] private AudioClip _bodyFallClip;
        [SerializeField] private AudioClip _meleeDamageClip;
        [SerializeField] private AudioClip _bulletDamageClip;

        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddAudioSource(_audioSource);
            
            //Behaviours:
            entity.AddBehaviour(new PainSoundBehaviour(_painLevels));
            entity.AddBehaviour(new TakeDamageSoundBehaviour(_deathClips));
            entity.AddBehaviour(new BodyFallSoundBehaviour(_bodyFallClip));
        }
    }
}