using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public class UnitFireReadySystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Target> _targets;
        private readonly EcsPoolInject<StoppingDistance> _stoppingDistances;
        private readonly EcsPoolInject<CanFire> _canFire;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                var position = _positions.Value.Get(entity).value;
                var target = _targets.Value.Get(entity).value;
                if (target < 0) continue;

                var targetPosition = _positions.Value.Get(target).value;
                var stoppingDistance = _stoppingDistances.Value.Get(entity).value;

                if (math.distance(position, targetPosition) <= stoppingDistance)
                    SetCanFire(entity, true);
                else
                    SetCanFire(entity, false);
            }
        }

        private void SetCanFire(int entity, bool value)
        {
            ref var canFire = ref _canFire.Value.Get(entity);
            canFire.value = value;
        }
    }
}