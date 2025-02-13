using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class TakeDamageAnimSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<TakeDamageEvent> _events;
        private readonly EcsPoolInject<AnimatorView> _animators;
        private readonly EcsWorldInject _world;
        private static int _hash;

        public TakeDamageAnimSystem(string hashKey)
        {
            _hash = Animator.StringToHash(hashKey);
        }

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (TakeDamageEvent damageEvent in _events.Value)
            {
                if (!damageEvent.target.Unpack(_world.Value, out int target))
                    continue;

                if (!_animators.Value.Has(target)) 
                    continue;

                Animator animator = _animators.Value.Get(target).value;
                animator.SetTrigger(_hash);
            }
        }
    }
}