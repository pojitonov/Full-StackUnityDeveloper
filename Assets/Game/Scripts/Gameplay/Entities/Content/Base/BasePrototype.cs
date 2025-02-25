using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(fileName = "Base", menuName = "SampleGame/Entities/New Base")]
    public class BasePrototype : EcsPrototype
    {
        [SerializeField] private int _health = 10;
        [SerializeField] private float _stoppingOffset = 3f;


        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<BaseTag>().Add(entity);
            world.GetPool<DeathTag>().Add(entity);
            world.GetPool<AttackableTag>().Add(entity);

            world.GetPool<StoppingOffset>().Add(entity).value = _stoppingOffset;
            
            world.GetPool<Health>().Add(entity) = new Health
            {
                current = _health,
                max = _health
            };
        }
    }
}