using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveAnimSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<MoveableTag, AnimatorView>> _moveables;
        private readonly EcsUseCaseInject<MoveUseCase> _moveUseCase;
        private static int _hash;

        public MoveAnimSystem(string hashKey)
        {
            _hash = Animator.StringToHash(hashKey);
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _moveables.Value)
            {
                ref AnimatorView animator = ref _moveables.Pools.Inc2.Get(entity);
                bool isMoving = _moveUseCase.Value.IsMoving(entity);
                animator.value.SetBool(_hash, isMoving);
            }
        }
    }
}