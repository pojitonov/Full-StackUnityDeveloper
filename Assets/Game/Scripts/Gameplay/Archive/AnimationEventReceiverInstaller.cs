// using Leopotam.EcsLite;
// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class AnimationEventReceiverInstaller : EcsViewInstaller
//     {
//         [SerializeField] private AnimationEventReceiver _animationEventReceiver;
//         
//         public override void Install(in EcsWorld world, in int entity)
//         {
//             world.GetPool<AnimationEventReceiverView>().Add(entity).value = _animationEventReceiver;
//         }
//     }
// }