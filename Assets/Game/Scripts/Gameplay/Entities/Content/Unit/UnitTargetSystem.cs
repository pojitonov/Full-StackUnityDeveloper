using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public class UnitTargetSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<SetTargetEvent> _setTargetEvent;
        
        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<TeamType, Position, Target>> _units;
        private readonly EcsFilterInject<Inc<AttackableTag, Position, EcsName>> _attackables;
        private readonly EcsPoolInject<TeamType> _teamTypes;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Target> _targets;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                var teamType = _teamTypes.Value.Get(entity);
                var position = _positions.Value.Get(entity).value;

                var enemyEntity = FindClosestEnemy(entity, teamType, position);
                if (enemyEntity != -1) 
                    SetTarget(entity, enemyEntity);
            }
        }

        private int FindClosestEnemy(int entity, TeamType teamType, float3 position)
        {
            float closestDistance = float.MaxValue;
            int closestEnemy = -1;

            foreach (var enemy in _attackables.Value)
            {
                if (entity == enemy) continue;

                if (_teamTypes.Value.Has(enemy))
                {
                    var enemyType = _teamTypes.Value.Get(enemy);
                    if (teamType == enemyType) continue;
                }

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

        private void SetTarget(int entity, int enemy)
        {
            ref var target = ref _targets.Value.Get(entity);
            target.target = _world.Value.PackEntity(enemy);

            _setTargetEvent.Value.Fire(new SetTargetEvent
            {
                target = target.target
            });
        }
    }
}
