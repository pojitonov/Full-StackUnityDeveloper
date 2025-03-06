using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class FireProjectileSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<AnimationEvent> _events;
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<BowWeapon> _bowWeapons;
        private readonly EcsUseCaseInject<FireProjectileUseCase> _fireProjectileUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (AnimationEvent animationEvent in _events.Value)
            {
                if (!animationEvent.entity.Unpack(_world.Value, out int entity))
                    continue;

                if (!_bowWeapons.Value.Has(entity))
                    continue;

                ref var bowWeapon = ref _bowWeapons.Value.Get(entity);
                _fireProjectileUseCase.Value.Fire(entity, bowWeapon.Projectile);
            }
        }
    }
}