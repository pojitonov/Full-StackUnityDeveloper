using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<MoveableTag, MoveEnabled>> _filter;
        private readonly EcsUseCaseInject<MoveUseCase> _moveUseCase;

        public void Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;
            foreach (int entity in _filter.Value) 
                _moveUseCase.Value.MoveStep(in entity, in deltaTime);
        }
    }
}