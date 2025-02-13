using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public class UnitFindEnemiesSystem : IEcsRunSystem
    {
        private const float MAX_DETECTION_RANGE = 100f;

        private readonly EcsFilterInject<Inc<UnitDirection, TeamType, EcsName, StoppingDistance>> _movables;
        private readonly EcsPoolInject<TeamType> _teamTypes;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<StoppingDistance> _stoppingDistances;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _movables.Value)
            {
                var teamType = _teamTypes.Value.Get(entity);
                var position = _positions.Value.Get(entity).value;
                var stoppingDistance = _stoppingDistances.Value.Get(entity).value;

                var enemy = FindClosestEnemy(entity, teamType, position);
                if (enemy == -1) continue;

                var direction = CalculateDirection(enemy, position, stoppingDistance);
                SetDirection(entity, direction);
            }
        }

        private int FindClosestEnemy(int entity, TeamType teamType, float3 position)
        {
            float closestDistance = float.MaxValue;
            int closestEnemyEntity = -1;

            foreach (var enemy in _movables.Value)
            {
                if (entity == enemy) continue;

                var enemyType = _teamTypes.Value.Get(enemy);
                if (teamType == enemyType) continue;

                var otherPosition = _positions.Value.Get(enemy).value;
                float distance = math.distance(position, otherPosition);

                if (distance < closestDistance && distance <= MAX_DETECTION_RANGE)
                {
                    closestDistance = distance;
                    closestEnemyEntity = enemy;
                }
            }

            return closestEnemyEntity;
        }

        private float3 CalculateDirection(int closestEnemyEntity, float3 position, float stoppingDistance)
        {
            var closestEnemyPosition = _positions.Value.Get(closestEnemyEntity).value;
            var direction = math.normalize(closestEnemyPosition - position);

            return math.distance(position, closestEnemyPosition) > stoppingDistance ? direction : float3.zero;
        }

        private void SetDirection(int entity, float3 direction)
        {
            ref var unitDirection = ref _movables.Pools.Inc1.Get(entity);
            unitDirection.value = direction;
        }
    }
}
