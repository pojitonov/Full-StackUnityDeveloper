using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class UnitInitSystem : IEcsInitSystem
    {
        private readonly EcsFilterInject<Inc<EcsName, StoppingDistance>> _units;
        private readonly EcsPoolInject<EcsName> _names;
        private readonly EcsPoolInject<StoppingDistance> _stoppingDistances;

        public void Init(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                var name = _names.Value.Get(entity).value;

                float stoppingDistance = GetStoppingDistance(name);

                ref var stoppingDistanceComponent = ref _stoppingDistances.Value.Get(entity);
                stoppingDistanceComponent.value = stoppingDistance;
            }
        }

        private static float GetStoppingDistance(string unitName)
        {
            return unitName switch
            {
                "Swordman" => 2f,
                "Archer" => 10f
            };
        }
    }
}