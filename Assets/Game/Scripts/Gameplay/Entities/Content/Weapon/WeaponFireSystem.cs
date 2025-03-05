using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class WeaponFireSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<AnimationEvent> _events;
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<WeaponTag> _weapons;
        private readonly EcsPoolInject<FireWeaponEvent> _fireWeaponEvents;

        public void Run(IEcsSystems systems)
        {
            foreach (AnimationEvent animationEvent in _events.Value)
            {
                if (!animationEvent.entity.Unpack(_world.Value, out int entity))
                    continue;

                if (!_weapons.Value.Has(entity))
                    continue;

                _fireWeaponEvents.Value.Add(entity);
            }
        }
    }

    public struct FireWeaponEvent { }
}