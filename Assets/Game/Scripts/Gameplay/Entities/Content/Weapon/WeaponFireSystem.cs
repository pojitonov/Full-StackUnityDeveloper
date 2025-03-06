using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class WeaponFireSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<AnimationEvent> _events;
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<Weapon> _weapons;
        private readonly EcsUseCaseInject<FireProjectileUseCase> _fireProjectileUseCase;
        private readonly EcsUseCaseInject<FireMeleeUseCase> _fireMeleeUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (AnimationEvent animationEvent in _events.Value)
            {
                if (!animationEvent.entity.Unpack(_world.Value, out int entity))
                    continue;

                if (!_weapons.Value.Has(entity))
                    continue;

                ref var weapon = ref _weapons.Value.Get(entity);

                switch (weapon.Type)
                {
                    case WeaponType.Bow:
                        _fireProjectileUseCase.Value.Fire(entity, weapon.Projectile);
                        break;

                    case WeaponType.Melee:
                        _fireMeleeUseCase.Value.Fire(entity);
                        break;
                }
            }
        }
    }

}