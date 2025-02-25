using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class FireAnimSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<FireEvent> _events;
        private readonly EcsPoolInject<AnimatorView> _animators;
        private readonly EcsWorldInject _world;
        private static int _hash;

        public FireAnimSystem(string hashKey)
        {
            _hash = Animator.StringToHash(hashKey);
        }
        
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (FireEvent fireEvent in _events.Value)
            {
                if (!fireEvent.entity.Unpack(_world.Value, out int target))
                    continue;

                if (!_animators.Value.Has(target)) 
                    continue;

                Animator animator = _animators.Value.Get(target).value;
                animator.SetTrigger(_hash);
            }
        }
    }
}