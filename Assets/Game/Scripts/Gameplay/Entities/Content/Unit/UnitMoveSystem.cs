using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public class UnitMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag>> _characters;
        private readonly EcsPoolInject<MoveDirection> _moveDirections;
        private readonly EcsPoolInject<RotateDirection> _rotateDirections;
        private readonly EcsPoolInject<UnitDirection> _unitDirections;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _characters.Value)
            {
                ref UnitDirection unitDirection = ref _unitDirections.Value.Get(entity);
                ref MoveDirection moveDirection = ref _moveDirections.Value.Get(entity);
                ref RotateDirection rotateDirection = ref _rotateDirections.Value.Get(entity);
                
                moveDirection.value = unitDirection.value;
                rotateDirection.value = unitDirection.value;
            }
        }
    }
}