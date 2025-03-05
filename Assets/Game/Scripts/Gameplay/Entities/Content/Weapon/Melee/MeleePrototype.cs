using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(fileName = "Melee Weapon", menuName = "SampleGame/Entities/New Melee Weapon")]
    public sealed class MeleePrototype : EcsPrototype
    {
        private readonly EcsUseCaseInject<FireUseCase> _fireUseCase;

        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<WeaponTag>().Add(entity);
        }
        
        public void Attack(in int entity)
        {
            Debug.Log("Melee Attack");
        }
    }
}