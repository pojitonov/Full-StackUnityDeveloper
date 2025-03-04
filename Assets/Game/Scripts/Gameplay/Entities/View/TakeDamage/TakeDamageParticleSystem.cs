using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class TakeDamageParticleSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<TakeDamageEvent> _events;
        private readonly EcsPoolInject<ParticleSystemView> _particles;
        private readonly EcsWorldInject _world;
        
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (TakeDamageEvent damageEvent in _events.Value)
            {
                if (!damageEvent.target.Unpack(_world.Value, out int target))
                    continue;
                
                ParticleSystem particles = _particles.Value.Get(target).value;
                particles.Play();
            }
        }
    }
}