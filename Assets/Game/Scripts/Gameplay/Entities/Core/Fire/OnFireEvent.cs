using System;
using Leopotam.EcsLite;

namespace SampleGame
{
    [Serializable]
    public struct OnFireEvent
    {
        public EcsPackedEntity entity;
    }
}