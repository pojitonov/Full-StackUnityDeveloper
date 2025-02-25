using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackAnimationEventSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<OnAttackAnimationEvent>> _attackAnimationEventFilter;
        private readonly EcsWorldInject _world;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _attackAnimationEventFilter.Value)
            {
                Debug.Log("Attack Animation event received!");
            }
        }
    }
}