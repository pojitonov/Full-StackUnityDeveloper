using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class UnitFireSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<CanFire> _canFireUnits;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsUseCaseInject<FireUseCase> _fireUseCase;
        private readonly EcsEventInject<OnFireEvent> _fireEvents;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value) 
                Fire(entity);
        }

        private void Fire(int entity)
        {
            if (!_canFireUnits.Value.Get(entity).value)
                return;
            
            if (!_fireUseCase.Value.IsCooldownExpired(entity))
                return;
            
            if (!_healthUseCase.Value.Exists(entity))
                return;
            
            _fireUseCase.Value.ResetCooldown(entity);
            _fireEvents.Value.Fire(new OnFireEvent {entity = _world.Value.PackEntity(entity)});
        }
    }
}