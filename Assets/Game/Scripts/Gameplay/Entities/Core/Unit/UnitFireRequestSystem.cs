using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class UnitFireRequestSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<FireEvent> _fireEvents;
        
        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<FireEnabled> _canFire;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsUseCaseInject<FireCooldownUseCase> _fireCooldownUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value) 
                Fire(entity);
        }

        private void Fire(int entity)
        {
            if (!_canFire.Value.Get(entity).value)
                return;
            
            if (!_fireCooldownUseCase.Value.IsCooldownExpired(entity))
                return;
            
            if (!_healthUseCase.Value.Exists(entity))
                return;
            
            _fireCooldownUseCase.Value.ResetCooldown(entity);
            _fireEvents.Value.Fire(new FireEvent {entity = _world.Value.PackEntity(entity)});
        }
    }
}