using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    public sealed class TransformBaker : MonoBehaviour, IEcsEntityInstaller
    {
        public void Install(EcsWorld world, int entity)
        {
            world.GetPool<Position>().Add(entity).value = transform.position;
            world.GetPool<Rotation>().Add(entity).value = transform.rotation;
        }
    }
}