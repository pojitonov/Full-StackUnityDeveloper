// using Leopotam.EcsLite;
// using Leopotam.EcsLite.Di;
// using UnityEngine;
//
// namespace SampleGame
// {
//     public class AnimationEventSystem : IEcsRunSystem
//     {
//         private readonly EcsWorldInject _world;
//         private readonly EcsFilterInject<Inc<UnitTag>> _filter;
//         private readonly EcsPoolInject<AnimationEventReceiverView> _eventReceivers;
//         private readonly EcsEventInject<OnAnimationEvent> _attackEvent;
//         private static string _key;
//
//         public AnimationEventSystem(string key)
//         {
//             _key = key;
//         }
//
//         public void Run(IEcsSystems systems)
//         {
//             foreach (var entity in _filter.Value)
//             {
//                 var eventReceiver = _eventReceivers.Value.Get(entity).value;
//                 var eventStatus = _eventReceivers.Value.Get(entity).isSubscribed;
//                 if (!eventStatus)
//                 {
//                     eventReceiver.Subscribe(_key, () => HandleAnimationEvent(entity));
//                     _eventReceivers.Value.Get(entity).isSubscribed = true;
//                     Debug.Log($"Entity {entity} Subscribed to AnimationEventReceiver");
//                 }
//             }
//         }
//
//         private void HandleAnimationEvent(int entity)
//         {
//             _attackEvent.Value.Fire(new OnAnimationEvent { entity = _world.Value.PackEntity(entity) });
//             Debug.Log($"Entity {entity} triggered OnAnimationEvent");
//         }
//     }
// }