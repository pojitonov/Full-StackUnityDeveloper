using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PistolVfxInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private ParticleSystem _fireParticle;
        [SerializeField] private Transform _firePoint;

        protected override void Install(IWeaponEntity entity)
        {
            entity.GetFireEvent().Subscribe(_fireParticle.Play);
        }
    }
}