using Leopotam.EcsLite;

namespace SampleGame
{
    public struct OnTakeDamageEvent
    {
        public EcsPackedEntity source;
        public EcsPackedEntity target;
        public int damage;
    }
}