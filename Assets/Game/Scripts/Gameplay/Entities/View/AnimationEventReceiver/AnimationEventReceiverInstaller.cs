using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    public sealed class AnimationEventReceiverInstaller : EcsViewInstaller
    {
        [SerializeField] private AnimationEventReceiver _animationEventReceiver;
        [SerializeField] private string _eventName = "OnAttackAnimation";

        private readonly EcsEventInject<OnAttackAnimationEvent> _attackAnimationEvent;

        public override void Install(in EcsWorld world, in int entity)
        {
            _animationEventReceiver.Subscribe(_eventName, HandleAnimationEvent);
            world.GetPool<AnimationEventReceiverView>().Add(entity).value = _animationEventReceiver;
        }

        private void HandleAnimationEvent()
        {
            _attackAnimationEvent.Value.Fire(new OnAttackAnimationEvent());
            Debug.Log($"Animation event triggered: {_eventName}");
        }
    }
}