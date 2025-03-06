using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public readonly struct FireProjectileUseCase
    {
        private readonly EcsEventInject<SpawnRequest> _spawnRequest;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Rotation> _rotations;
        private readonly EcsPoolInject<TeamType> _teams;
        private readonly EcsPoolInject<FireOffset> _fireOffsets;

        public void Fire(in int entity, in EcsPrototype projectile)
        {
            _spawnRequest.Value.Fire(new SpawnRequest
            {
                prefab = projectile,
                position = GetFirePoint(entity),
                rotation = _rotations.Value.Get(entity).value,
                team = _teams.Value.Get(entity)
            });
        }
        
        public float3 GetFirePoint(in int entity)
        {
            float3 position = _positions.Value.Get(entity).value;
            quaternion rotation = _rotations.Value.Get(entity).value;
            float3 offset = _fireOffsets.Value.Get(entity).value;
            return position + math.mul(rotation, offset);
        }
    }
}