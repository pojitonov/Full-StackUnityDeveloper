using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class UnitFireSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world;
        private readonly EcsPrototype _prefab;
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<CanFire> _fires;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsUseCaseInject<FireUseCase> _fireUseCase;
        private readonly EcsEventInject<FireEvent> _fireEvents;

        public UnitFireSystem(EcsPrototype prefab)
        {
            _prefab = prefab;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value) 
                Fire(entity);
        }

        private void Fire(int entity)
        {
            if (!_fires.Value.Get(entity).value)
                return;

            if (!_fireUseCase.Value.IsCooldownExpired(entity))
                return;

            if (!_healthUseCase.Value.Exists(entity))
                return;

            _fireUseCase.Value.Fire(entity, _prefab);
            _fireUseCase.Value.ResetCooldown(entity);

            _fireEvents.Value.Fire(new FireEvent {entity = _world.Value.PackEntity(entity)});
        }
    }
}