using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game
{
    public sealed class MoveSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<MoveableTag>> _moveables;
        private EcsPoolInject<MoveDirection> _moveDirections;
        private EcsPoolInject<MoveSpeed> _moveSpeeds;
        private EcsPoolInject<Position> _positions;

        public void Run(IEcsSystems systems)
        {
            var deltaTime = Time.deltaTime;
            
            foreach (var entity in _moveables.Value)
            {
                ref var moveDirection = ref _moveDirections.Value.Get(entity);
                ref var moveSpeed = ref _moveSpeeds.Value.Get(entity);
                ref var position = ref _positions.Value.Get(entity);

                position.value += moveDirection.value * moveSpeed.value * deltaTime;
            }
        }
    }
}