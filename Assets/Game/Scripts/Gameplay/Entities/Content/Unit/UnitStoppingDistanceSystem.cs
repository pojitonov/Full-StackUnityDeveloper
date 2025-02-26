using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class UnitStoppingDistanceSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<StoppingDistance, Target>> _units;
        private readonly EcsPoolInject<StoppingDistance> _stoppingDistances;
        private readonly EcsPoolInject<Target> _targets;
        private readonly EcsPoolInject<TargetingBase> _targetingBase;
        private readonly EcsWorldInject _world;
        private readonly EcsEventInject<SetTargetEvent> _events;
        private readonly EcsPoolInject<BaseTag> _baseTags;
        private readonly EcsPoolInject<StoppingOffset> _stoppingOffsets;

        public void Run(IEcsSystems systems)
        {
            foreach (SetTargetEvent targetEvent in _events.Value)
            {
                if (!targetEvent.target.Unpack(_world.Value, out int newTarget))
                    continue;

                if (!_baseTags.Value.Has(newTarget))
                    continue;

                float baseStoppingDistance = 0f;
                if (_stoppingOffsets.Value.Has(newTarget))
                {
                    baseStoppingDistance = _stoppingOffsets.Value.Get(newTarget).value;
                }

                foreach (var entity in _units.Value)
                {
                    ref var target = ref _targets.Value.Get(entity);

                    if (target.target.Equals(targetEvent.target))
                    {
                        ref var stoppingDistance = ref _stoppingDistances.Value.Get(entity);

                        if (!_targetingBase.Value.Has(entity))
                        {
                            stoppingDistance.value += baseStoppingDistance;

                            _targetingBase.Value.Add(entity).newStoppingDistance = baseStoppingDistance;
                        }
                    }
                }
            }
        }
    }
}