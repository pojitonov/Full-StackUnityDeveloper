using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(fileName = "Unit", menuName = "SampleGame/Entities/New Unit")]
    public class UnitPrototype : EcsPrototype
    {
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] float _rotationSpeed = 10f;
        [SerializeField] private int _health = 5;
        [SerializeField] private float _fireCooldown = 0.5f;

        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<UnitTag>().Add(entity);
            world.GetPool<DeathTag>().Add(entity);
            
            world.GetPool<UnitDirection>().Add(entity);
            world.GetPool<CanFire>().Add(entity);
            world.GetPool<Target>().Add(entity);
            
            world.GetPool<MoveableTag>().Add(entity);
            world.GetPool<MoveSpeed>().Add(entity).value = _moveSpeed;
            world.GetPool<MoveDirection>().Add(entity).value = new float3(0f, 0f, 1f);

            world.GetPool<RotatableTag>().Add(entity);
            world.GetPool<RotateDirection>().Add(entity).value = new float3(0f, 0f, -1f);
            world.GetPool<RotationSpeed>().Add(entity).value = _rotationSpeed;
            
            world.GetPool<StoppingDistance>().Add(entity);
            
            world.GetPool<Health>().Add(entity) = new Health
            {
                current = _health,
                max = _health
            };
            
            world.GetPool<FireOffset>().Add(entity).value = new float3(0, 1.5f, 2f);
            world.GetPool<FireCooldown>().Add(entity) = new FireCooldown
            {
                current = 0,
                duration = _fireCooldown
            };
        }
    }
}