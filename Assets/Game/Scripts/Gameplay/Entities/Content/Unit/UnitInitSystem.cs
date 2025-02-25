using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class UnitInitSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<EcsName> _names;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _units.Value)
            {
                var name = _names.Value.Get(entity).value;
            }
        }
    }
}