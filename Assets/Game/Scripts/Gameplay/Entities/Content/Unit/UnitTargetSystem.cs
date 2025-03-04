using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public class UnitTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<TeamType> _teamTypes;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsUseCaseInject<UnitTargetUseCase> _useCase;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                var teamType = _teamTypes.Value.Get(entity);
                var position = _positions.Value.Get(entity).value;

                var enemyEntity = _useCase.Value.FindClosestEnemy(entity, teamType, position);
                if (enemyEntity != -1) 
                    _useCase.Value.SetTarget(entity, enemyEntity);
            }
        }
    }
}