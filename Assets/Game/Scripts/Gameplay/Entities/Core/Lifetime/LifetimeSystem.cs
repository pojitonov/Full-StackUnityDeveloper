using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class LifetimeSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Lifetime>> _lifetimes;
        private readonly EcsEventInject<DespawnRequest> _despawnRequests;

        public void Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;
            foreach (int entity in _lifetimes.Value)
            {
                ref Lifetime lifetime = ref _lifetimes.Pools.Inc1.Get(entity);
                lifetime.value -= deltaTime;
                if (lifetime.value <= 0)
                    _despawnRequests.Value.Fire(new DespawnRequest {entity = entity});
            }
        }
    }
}