using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public readonly struct UnitTargetUseCase
    {
        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<AttackableTag>> _units;
        private readonly EcsPoolInject<TeamType> _teamTypes;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Target> _targets;

        public int FindClosestEnemy(int entity, TeamType teamType, float3 position)
        {
            float closestDistance = float.MaxValue;
            int closestEnemy = -1;

            foreach (var enemy in _units.Value)
            {
                if (entity == enemy) continue;
                
                if (_teamTypes.Value.Has(enemy) && _teamTypes.Value.Get(enemy) == teamType)
                    continue;

                var otherPosition = _positions.Value.Get(enemy).value;
                float distance = math.distance(position, otherPosition);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }

        public void SetTarget(int entity, int enemy)
        {
            ref var target = ref _targets.Value.Get(entity);
            target.target = _world.Value.PackEntity(enemy);
        }
    }
}