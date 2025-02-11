using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public class TransformViewSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<TransformView, Position, Rotation>> _entities;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _entities.Value)
            {
                var transform = _entities.Pools.Inc1.Get(entity);
                var position = _entities.Pools.Inc2.Get(entity);
                var rotation = _entities.Pools.Inc3.Get(entity);
                
                transform.value.SetPositionAndRotation(position.value, rotation.value);
            }
        }
    }
}