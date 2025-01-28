using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PistolVisualInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private ParticleSystem _fireParticle;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private AudioSource _audioSource;

        protected override void Install(IWeaponEntity entity)
        {
            entity.GetFireEvent().Subscribe(() =>
                {
                    _fireParticle.Play();
                    _audioSource.Play();
                });
        }
    }
}