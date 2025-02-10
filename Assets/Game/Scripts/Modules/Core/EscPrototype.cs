using UnityEngine;

namespace Leopotam.EcsLite
{
    public abstract class EscPrototype : ScriptableObject
    {
        public virtual string Name => name;

        public int Create(in EcsWorld world)
        {
            int entity = world.NewEntity();
            world.GetPool<EcsName>().Add(entity).value = Name;
            Install(in world, in entity);
            return entity;
        }

        protected abstract void Install(in EcsWorld world, in int entity);
    }
}