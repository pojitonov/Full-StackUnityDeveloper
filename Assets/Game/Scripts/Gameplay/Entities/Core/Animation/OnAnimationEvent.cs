using System;
using Leopotam.EcsLite;

namespace SampleGame
{
    [Serializable]
    public struct OnAnimationEvent
    {
        public EcsPackedEntity entity;
    }
}