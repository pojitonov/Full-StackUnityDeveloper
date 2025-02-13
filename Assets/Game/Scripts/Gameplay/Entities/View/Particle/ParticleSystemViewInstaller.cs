using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    public sealed class ParticleSystemViewInstaller : EcsViewInstaller
    {
        [SerializeField] private ParticleSystem _particleSystem;
        
        public override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<ParticleSystemView>().Add(entity).value = _particleSystem;
        }
    }
}