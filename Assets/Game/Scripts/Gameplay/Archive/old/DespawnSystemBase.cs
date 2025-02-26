// using Leopotam.EcsLite;
// using Leopotam.EcsLite.Di;
//
// namespace SampleGame
// {
//     public sealed class DespawnSystemBase : IEcsRunSystem
//     {
//         private readonly EcsFilterInject<Inc<DespawnRequest>> _despawnRequests = EcsConsts.EventWorld;
//         private readonly EcsWorldInject _world;
//
//         public void Run(IEcsSystems systems)
//         {
//             foreach (int evt in _despawnRequests.Value)
//             {
//                 ref DespawnRequest request = ref _despawnRequests.Pools.Inc1.Get(evt);
//                 _world.Value.DelEntity(request.entity);
//                 
//                 _despawnRequests.Pools.Inc1.Del(evt);
//             }
//         }
//     }
// }