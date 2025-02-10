using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Character", menuName = "Game/Entities/New Character")]
    public class CharacterPrototype : EscPrototype
    {
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] float _rotationSpeed = 10f;

        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<CharacterTag>().Add(entity);
            world.GetPool<UnitDirection>().Add(entity);
            
            world.GetPool<MoveableTag>().Add(entity);
            world.GetPool<MoveSpeed>().Add(entity).value = _moveSpeed;
            world.GetPool<MoveDirection>().Add(entity).value = new float3(0f, 0f, 1f);

            world.GetPool<RotatableTag>().Add(entity);
            world.GetPool<RotateDirection>().Add(entity).value = new float3(0f, 0f, -1f);
            world.GetPool<RotateSpeed>().Add(entity).value = _rotationSpeed;
        }
    }
}