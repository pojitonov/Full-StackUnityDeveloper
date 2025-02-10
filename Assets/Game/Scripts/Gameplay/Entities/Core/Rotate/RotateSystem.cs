using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game
{
    public sealed class RotateSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<RotatableTag>> _rotatables;
        private readonly EcsPoolInject<Rotation> _rotations;
        private readonly EcsPoolInject<RotateSpeed> _rotateSpeeds;
        private readonly EcsPoolInject<RotateDirection> _rotateDirections;

        public void Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;

            foreach (var entity in _rotatables.Value)
            {
                ref Rotation rotation = ref _rotations.Value.Get(entity);
                ref RotateDirection direction = ref _rotateDirections.Value.Get(entity);
                ref RotateSpeed speed = ref _rotateSpeeds.Value.Get(entity);

                RotateUseCase.RotateStep(ref rotation, in direction, in speed, in deltaTime);
            }
        }
    }
}