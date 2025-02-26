using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public class UnitFireReadySystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<UnitTag, Position, Target, StoppingDistance, FireEnabled>> _units;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Target> _targets;
        private readonly EcsPoolInject<StoppingDistance> _stoppingDistances;
        private readonly EcsPoolInject<FireEnabled> _canFire;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                ref var targetComp = ref _targets.Value.Get(entity);
                if (!targetComp.target.Unpack(_world.Value, out int target)) 
                {
                    SetCanFire(entity, false);
                    continue;
                }

                var position = _positions.Value.Get(entity).value;
                var stoppingDistance = _stoppingDistances.Value.Get(entity).value;
                var targetPosition = _positions.Value.Get(target).value;

                SetCanFire(entity, math.distance(position, targetPosition) <= stoppingDistance);
            }
        }

        private void SetCanFire(int entity, bool value)
        {
            ref var canFire = ref _canFire.Value.Get(entity);
            canFire.value = value;
        }
    }
}