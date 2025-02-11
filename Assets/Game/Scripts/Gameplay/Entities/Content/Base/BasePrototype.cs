using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(fileName = "Base", menuName = "SampleGame/Entities/New Base")]
    public class BasePrototype : EcsPrototype
    {
        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<BaseTag>().Add(entity);
        }
    }
}