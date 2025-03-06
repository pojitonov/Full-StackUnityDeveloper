using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(fileName = "Banner", menuName = "SampleGame/Entities/New Banner")]
    public class BannerPrototype : EcsPrototype
    {
        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<BannerTag>().Add(entity);
        }
    }
}