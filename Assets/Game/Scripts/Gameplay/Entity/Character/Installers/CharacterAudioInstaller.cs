using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterAudioInstaller : SceneEntityInstaller
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private PainSoundBehaviour.Level[] _painLevels;
        [SerializeField] private AudioClip[] _deathClips;
        [SerializeField] private AudioClip _bodyFallClip;
        [SerializeField] private AudioClip[] _moveStepClips;
        [SerializeField] private AudioClip _meleeDamageClip;
        [SerializeField] private AudioClip _bulletDamageClip;

        public override void Install(IEntity entity)
        {
            entity.AddAudioSource(_audioSource);
            
            entity.AddBehaviour(new PainSoundBehaviour(_painLevels));
            entity.AddBehaviour(new TakeDamageSoundBehaviour(_deathClips));
            entity.AddBehaviour(new BodyFallSoundBehaviour(_bodyFallClip));
            entity.AddBehaviour(new DeathSoundBehaviour(_deathClips));
            entity.AddBehaviour(new MoveStepSoundBehaviour(_moveStepClips));
            entity.AddBehaviour(new TakeDamageSoundTypeBehaviour(_meleeDamageClip, _bulletDamageClip));
        }
    }
}