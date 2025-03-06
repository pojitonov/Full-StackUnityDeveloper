using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public readonly struct FireMeleeUseCase
    {
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsFilterInject<Inc<AttackableTag>> _enemies;
        private readonly EcsUseCaseInject<TakeDamageUseCase> _takeDamageUseCase;
        private readonly EcsUseCaseInject<TargetUseCase> _targetUseCase;

        public void Fire(int entity)
        {
            var damage = 1;
            var source = _world.Value.PackEntity(entity);

            foreach (int target in _enemies.Value)
            {
                if (target == entity)
                    continue;

                _takeDamageUseCase.Value.TakeDamage(target, damage, source);
            }
        }
    }
}