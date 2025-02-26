using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class UnitFireAnimationSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world;
        private readonly EcsEventInject<OnAnimationEvent> _events;
        private readonly EcsUseCaseInject<FireUseCase> _fireUseCase;
        private readonly EcsPrototype _prefab;

        public UnitFireAnimationSystem(EcsPrototype prefab)
        {
            _prefab = prefab;
        }
        
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (OnAnimationEvent animationEvent in _events.Value)
            {
                if (!animationEvent.entity.Unpack(_world.Value, out int entity))
                    continue;
                
                _fireUseCase.Value.Fire(entity, _prefab);
            }
        }
    }
}