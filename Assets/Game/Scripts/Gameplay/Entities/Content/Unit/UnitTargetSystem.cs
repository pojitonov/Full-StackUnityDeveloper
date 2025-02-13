using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public class UnitTargetSystem : IEcsRunSystem
    {
        private const float MAX_DETECTION_RANGE = 100f;

        private readonly EcsFilterInject<Inc<TeamType, Position, Target>> _units;
        private readonly EcsPoolInject<TeamType> _teamTypes;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Target> _targets;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                var teamType = _teamTypes.Value.Get(entity);
                var position = _positions.Value.Get(entity).value;

                var enemy = FindClosestEnemy(entity, teamType, position);
                if (enemy != -1)
                {
                    SetTarget(entity, enemy);
                }
            }
        }

        private int FindClosestEnemy(int entity, TeamType teamType, float3 position)
        {
            float closestDistance = float.MaxValue;
            int closestEnemyEntity = -1;

            foreach (var enemy in _units.Value)
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

        private void SetTarget(int entity, int enemy)
        {
            ref var Target = ref _units.Pools.Inc3.Get(entity);
            Target.value = enemy;
        }
    }
}
