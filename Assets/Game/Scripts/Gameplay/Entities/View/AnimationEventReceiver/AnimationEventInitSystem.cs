using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public class AnimationEventInitSystem : IEcsRunSystem, IEcsDestroySystem
    {
        private readonly EcsFilterInject<Inc<UnitTag>> _filter;
        private readonly EcsPoolInject<AnimationEventReceiverView> _eventReceivers;
        private readonly EcsEventInject<OnAttackAnimationEvent> _attackEvent;
        private static string _hashKey;

        public AnimationEventInitSystem(string hashKey)
        {
            _hashKey = hashKey;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var eventReceiver = _eventReceivers.Value.Get(entity).value;
                var eventStatus = _eventReceivers.Value.Get(entity).isSubscribed;
                if (!eventStatus)
                {
                    eventReceiver.Subscribe(_hashKey, HandleAnimationEvent);
                    _eventReceivers.Value.Get(entity).isSubscribed = true;
                }
            }
        }

        public void Destroy(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var eventReceiver = _eventReceivers.Value.Get(entity).value;
                eventReceiver.Unsubscribe(_hashKey, HandleAnimationEvent);
            }
        }

        private void HandleAnimationEvent()
        {
            Debug.Log("HandleAnimationEvent");
            // _attackEvent.Value.Fire(new OnAttackAnimationEvent());
        }
    }
}