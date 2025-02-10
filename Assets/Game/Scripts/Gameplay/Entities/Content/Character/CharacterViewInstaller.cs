using Leopotam.EcsLite;
using UnityEngine;

namespace Game
{
    public sealed class CharacterViewInstaller : EcsViewInstaller
    {
        [SerializeField] private Transform _transform;

        public override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<TransformView>().Add(entity).value = _transform;
        }
    }
}