using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class RotationSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<RotatableTag, RotationEnabled>> _rotateables;
        private readonly EcsUseCaseInject<RotateUseCase> _rotateUseCase;

        public void Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;
            foreach (int entity in _rotateables.Value) 
                _rotateUseCase.Value.RotateStep(entity, deltaTime);
        }
    }
}