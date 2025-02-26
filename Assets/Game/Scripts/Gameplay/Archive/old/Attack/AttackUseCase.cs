// using Leopotam.EcsLite;
// using Leopotam.EcsLite.Di;
// using Unity.Mathematics;
//
// namespace SampleGame
// {
//     public readonly struct AttackUseCase
//     {
//         private readonly EcsPoolInject<Position> _positions;
//         private readonly EcsPoolInject<Rotation> _rotations;
//         private readonly EcsPoolInject<TeamType> _teams;
//         private readonly EcsPoolInject<AttackCooldown> _cooldown;
//         private readonly EcsEventInject<SpawnRequest> _spawnRequest;
//
//         public void Attack(in int entity, in EcsPrototype prefab)
//         {
//            
//         }
//         
//
//         public bool IsCooldownExpired(in int entity)
//         {
//             ref var cooldown = ref _cooldown.Value.Get(entity);
//             return cooldown.current <= 0;
//         }
//
//         public void ResetCooldown(int entity)
//         {
//             ref var cooldown = ref _cooldown.Value.Get(entity);
//             cooldown.current = cooldown.duration;
//         }
//     }
// }