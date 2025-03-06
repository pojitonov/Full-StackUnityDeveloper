using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class UnitFireSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<AnimationEvent> _events;
        
        private readonly EcsWorldInject _world;
        private readonly EcsUseCaseInject<FireProjectileUseCase> _fireProjectileUseCase;
        private readonly EcsPrototype _prefab;

        public UnitFireSystem(EcsPrototype prefab)
        {
            _prefab = prefab;
        }
        
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (AnimationEvent animationEvent in _events.Value)
            {
                if (!animationEvent.entity.Unpack(_world.Value, out int entity))
                    continue;
                
                _fireProjectileUseCase.Value.Fire(entity, _prefab);
            }
        }
    }
}