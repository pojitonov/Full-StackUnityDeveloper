using System;
using Leopotam.EcsLite;

namespace SampleGame
{
    [Serializable]
    public struct AnimationEvent
    {
        public EcsPackedEntity entity;
    }
}