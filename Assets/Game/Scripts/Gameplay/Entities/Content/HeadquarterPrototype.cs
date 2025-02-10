using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Headquarter", menuName = "Game/Entities/New Headquarter")]
    public class HeadquarterPrototype : EscPrototype
    {
        [SerializeField] float _rotationSpeed = 0.2f;

        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<RotatableTag>().Add(entity);
            world.GetPool<RotateDirection>().Add(entity).value = new float3(0f, 0f, -1f);
            world.GetPool<RotateSpeed>().Add(entity).value = _rotationSpeed;
        }
    }
}