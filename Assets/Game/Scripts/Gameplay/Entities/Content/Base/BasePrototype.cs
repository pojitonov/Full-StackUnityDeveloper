using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(fileName = "Base", menuName = "SampleGame/Entities/New Base")]
    public class BasePrototype : EscPrototype
    {
        [SerializeField] float _rotationSpeed = 10f;

        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<BaseTag>().Add(entity);
            world.GetPool<UnitDirection>().Add(entity);
            
            world.GetPool<RotatableTag>().Add(entity);
            world.GetPool<RotateDirection>().Add(entity).value = new float3(0f, 0f, -1f);
            world.GetPool<RotateSpeed>().Add(entity).value = _rotationSpeed;
        }
    }
}