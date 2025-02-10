using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;
using UnityEngine;

namespace Game
{
    public sealed class RotatableSystem : IEcsRunSystem
    {
        private static readonly float3 UP = new(0, 1, 0);

        private readonly EcsFilterInject<Inc<RotatableTag>> _rotatables;
        private readonly EcsPoolInject<Rotation> _rotations;
        private readonly EcsPoolInject<RotateSpeed> _rotateSpeeds;
        private readonly EcsPoolInject<RotateDirection> _rotateDirections;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _rotatables.Value)
            {
                ref Rotation rotation = ref _rotations.Value.Get(entity);
                ref RotateSpeed speed = ref _rotateSpeeds.Value.Get(entity);
                ref RotateDirection direction = ref _rotateDirections.Value.Get(entity);

                if (!math.all(direction.value == float3.zero))
                {
                    quaternion target = quaternion.LookRotation(direction.value, UP);
                    rotation.value = math.slerp(rotation.value, target, speed.value * Time.deltaTime);
                }
            }    
        }
    }
}