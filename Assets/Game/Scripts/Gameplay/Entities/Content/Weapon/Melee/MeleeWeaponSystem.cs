using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class MeleeWeaponSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<MeleeWeapon> _meleeWeapons;

        public void Run(IEcsSystems systems)
        {
            var filter = _world.Value.Filter<MeleeWeapon>().End();

            foreach (int entity in filter)
            {
                ref MeleeWeapon meleeWeapon = ref _meleeWeapons.Value.Get(entity);

                Debug.Log($"Attack with: {meleeWeapon}");
            }
        }
    }
}