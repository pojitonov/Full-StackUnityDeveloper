using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public readonly struct FireMeleeUseCase
    {
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsFilterInject<Inc<AttackableTag>> _enemies;
        private readonly EcsPoolInject<Target> _targets;
        private readonly EcsUseCaseInject<TakeDamageUseCase> _takeDamageUseCase;

        public void Fire(in int entity, in int damage)
        {
            var source = _world.Value.PackEntity(entity);

            if (!_targets.Value.Has(entity))
                return;

            var targetEntity = _targets.Value.Get(entity).target;

            if (!targetEntity.Unpack(_world.Value, out int target))
                return;

            _takeDamageUseCase.Value.TakeDamage(target, damage, source);
        }
    }
}