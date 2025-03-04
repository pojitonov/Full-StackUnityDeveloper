using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class UnitFireAnimSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<AnimationEvent> _events;
        
        private readonly EcsWorldInject _world;
        private readonly EcsUseCaseInject<FireUseCase> _fireUseCase;
        private readonly EcsPrototype _prefab;

        public UnitFireAnimSystem(EcsPrototype prefab)
        {
            _prefab = prefab;
        }
        
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (AnimationEvent animationEvent in _events.Value)
            {
                if (!animationEvent.entity.Unpack(_world.Value, out int entity))
                    continue;
                
                _fireUseCase.Value.FireProjectile(entity, _prefab);
            }
        }
    }
}